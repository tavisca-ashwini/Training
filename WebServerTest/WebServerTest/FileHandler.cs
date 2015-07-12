﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebServerTest
{
    public class FileHandler
    {
        private string _contentPath;

        public FileHandler(string contentPath)
        {
            _contentPath = contentPath;
        }

        internal bool DoesFileExists(string directory)
        {
            return File.Exists(_contentPath + directory);
        }

        internal byte[] ReadFile(string path)
        {
            byte[] content = File.ReadAllBytes(_contentPath + path);
            return content;
        }
    }
}
