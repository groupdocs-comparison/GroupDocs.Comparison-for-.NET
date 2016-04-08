using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.Optimization;

namespace GroupDocsComparisonMvcDemo
{
    internal class EmbeddedVirtualPathProvider : VirtualPathProvider
    {
        private readonly VirtualPathProvider _previous;
        private readonly GroupDocsComparisonMvcDemo.ComparisonWidgetSettings _settings;

        public EmbeddedVirtualPathProvider(VirtualPathProvider previous, GroupDocsComparisonMvcDemo.ComparisonWidgetSettings settings)
        {
            _previous = previous;
            _settings = settings;
        }
        public override bool FileExists(string virtualPath)
        {
            return IsEmbeddedPath(virtualPath) || (_previous!=null && _previous.FileExists(virtualPath));
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return (IsEmbeddedPath(virtualPath) || _previous==null) ? null : _previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            if (!IsEmbeddedPath(virtualDir)) return _previous.GetDirectory(virtualDir);
            var resourcePrefix = getNameSpace() + ".";
            var clientPrefix = String.Format("~/{0}/", _settings.AppClientFilesPrefix);
            var prefix = virtualDir.Replace(clientPrefix, resourcePrefix).Replace('/', '.');
            var resources = typeof(GroupDocsComparisonMvcDemo.BundleConfigurator).Assembly.GetManifestResourceNames()
                                                                .Where(s => s.StartsWith(prefix))
                                                                .ToList();
            var files = (resources.Where(resourceName => !resourceName.Contains("main.js")).Select(
                resourceName => new {resourceName, virtualPath = resourceName.Replace(resourcePrefix, clientPrefix)})
                .Select(@t => getEmbeddedFile(@t.virtualPath, @t.resourceName))).ToList();

            return new EmbeddedVirtualDirectory(virtualDir, files);
        }
        public override bool DirectoryExists(string virtualDir)
        {
            return  IsEmbeddedPath(virtualDir) || _previous.DirectoryExists(virtualDir);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (!IsEmbeddedPath(virtualPath)) return _previous.GetFile(virtualPath);
            var prefix = String.Format("~/{0}/", BundleTable.EnableOptimizations?_settings.AppClientFilesPrefix:_settings.EmbeddedResourceUrl);
            var resourceName = virtualPath.Replace(prefix, String.Empty).Replace('/', '.');
            var nameSpace = getNameSpace();
            var manifestResourceName = string.Format("{0}.{1}", nameSpace, resourceName);
            return getEmbeddedFile(virtualPath, manifestResourceName);
        }

        private string getNameSpace()
        {
            return typeof(EmbeddedVirtualPathProvider).Assembly.GetName().Name;
        }

        private EmbeddedVirtualFile getEmbeddedFile(string virtualPath, string manifestResourceName)
        {
            var stream = typeof(EmbeddedVirtualPathProvider).Assembly.GetManifestResourceStream(manifestResourceName);
            return new EmbeddedVirtualFile(virtualPath, stream);
        }

        private bool IsEmbeddedPath(string path)
        {
            return path.StartsWith(String.Format("~/{0}", _settings.AppClientFilesPrefix));
        }
    }

    internal class EmbeddedVirtualFile : VirtualFile
    {
        private readonly Stream _stream;
        public EmbeddedVirtualFile(string virtualPath, Stream stream)
            : base(virtualPath)
        {
            if (stream == null)
            {
                stream = new MemoryStream();
            }
            _stream = stream;
        }
        public override Stream Open()
        {
            return _stream;
        }
    }

    internal class EmbeddedVirtualDirectory : VirtualDirectory
    {
        private readonly IList<EmbeddedVirtualFile> _files;

        public EmbeddedVirtualDirectory(string virtualPath, IList<EmbeddedVirtualFile> files) : base(virtualPath)
        {
            _files = files;
        }

        public override IEnumerable Directories
        {
            get { return new ArrayList(); }
        }

        public override IEnumerable Files
        {
            get { return _files; }
        }

        public override IEnumerable Children
        {
            get { return new ArrayList(); }
        }
    }
}