// -----------------------------------------------------------------------
// <copyright file="Archiver.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Dart.Tools.Zip
{
   internal class Archiver
   {
      #region Public Methods

      public static string Create(string path, IEnumerable<string> filesToInclude)
      {
         var zipPath = string.Empty;

         using (var memoryStream = new MemoryStream())
         {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
               foreach (var file in filesToInclude)
               {
                  if (File.Exists(file))
                     archive.CreateEntryFromFile(file, Path.GetFileName(file));
               }
            }

            zipPath = Path.Combine(path, $"dart_error_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.zip");
            using (var fileStream = new FileStream(zipPath, FileMode.OpenOrCreate))
            {
               memoryStream.Seek(0, SeekOrigin.Begin);
               memoryStream.CopyTo(fileStream);
            }
         }

         return zipPath;
      }

      #endregion Public Methods
   }
}