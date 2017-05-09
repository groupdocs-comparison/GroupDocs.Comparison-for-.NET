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
        public ComparingDocument(string documentName, string documentPassword = "")
        {
            DocumentName = documentName;
            DocumentPassword = documentPassword;
            Extention = GetFileType(documentName).ToLower();
            using (var fs = new FileStream(documentName, FileMode.Open, FileAccess.Read))
            {
                Content = new MemoryStream();
                fs.CopyTo(Content);
                Content.Seek(0, SeekOrigin.Begin);
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
        /// Gets the password of the document.
        /// </summary>
        /// <value>
        /// The password of the document.
        /// </value>
        public string DocumentPassword { get; private set; }
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
        public string Extention { get; private set; }

        internal static string GetFileType(string filePath)
        {
            var extension = GetExtension(filePath);

            if (string.IsNullOrWhiteSpace(extension)) return "Undefined";

            return ExtToFileType(extension);
        }

        private static string GetExtension(string filePath)
        {
            var extension = string.IsNullOrEmpty(filePath)
                                ? null
                                : Path.GetExtension(filePath);

            return (extension ?? "").Trim('.');
        }

        public static string ExtToFileType(string extension)
        {
            return extension;
        }
    }
}