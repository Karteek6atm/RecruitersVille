using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DocumentParser.src.parser;


namespace DocumentParser
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {

            const string documentPath = @"D:\Karteek\Projects\New folder\resume-parser-master\resume-parser-master\main\DocumentViewer\App_Data\Upload\Resume.docx";
            var dictionaryFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"resources\KeywordDictionary.xml");

            var response = Engine.Parse(documentPath, dictionaryFilePath);

            Console.WriteLine(response);
        }

    }

}
