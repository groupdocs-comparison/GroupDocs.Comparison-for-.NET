using System;
using System.IO;
using GroupDocs.Comparison.Common;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class ComparingDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparingDocument"/> class.
        /// </summary>
        /// <param name="documentName">Name of the document.</param>
        public ComparingDocument(string documentName)
        {
            DocumentName = documentName;
            Extention = GetFileType(documentName);
            using (var fs = new FileStream(documentName, FileMode.Open, FileAccess.Read))
            {
                Content = new MemoryStream();
                fs.CopyTo(Content);
                Content.Seek(0, SeekOrigin.Begin);
            }
            if ((Extention == FileType.Txt) || (Extention == FileType.Xml) || (Extention == FileType.Htm) || (Extention == FileType.Html) || (Extention == FileType.Html5) ||
                (Extention == FileType.Xhtml) || (Extention == FileType.Mhtml) || (Extention == FileType.Epub) || (Extention == FileType.Xps) || (Extention == FileType.Mht) || (Extention == FileType.Js) ||
                (Extention == FileType.Undefined))
            {
                Extention = FileType.Doc;
            }
        }
        
        /// <summary>
        /// Gets the name of the document.
        /// </summary>
        /// <value>
        /// The name of the document.
        /// </value>
        public string DocumentName { get; private set; }
        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public Stream Content { get; private set; }
        /// <summary>
        /// Gets the Extention.
        /// </summary>
        /// <value>
        /// The Extention.
        /// </value>
        public FileType Extention { get; private set; }

        internal static FileType GetFileType(string filePath)
        {
            var extension = GetExtension(filePath);

            if (string.IsNullOrWhiteSpace(extension)) return FileType.Undefined;

            return ExtToFileType(extension);
        }

        private static string GetExtension(string filePath)
        {
            var extension = string.IsNullOrEmpty(filePath)
                                ? null
                                : Path.GetExtension(filePath);

            return (extension ?? "").Trim('.');
        }

        public static FileType ExtToFileType(string extension)
        {
            FileType fileType;
            return Enum.TryParse(extension, true, out fileType)
                       ? fileType
                       : FileType.Undefined;
        }
    }
}