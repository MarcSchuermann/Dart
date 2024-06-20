// -----------------------------------------------------------------------
// <copyright file="IconSetter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using Dart.Common;
using Dart.Tools.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Schuermann.Dart.App.Common.Logger;

namespace Dart.Tools
{
   /// <summary>The icon setter class.</summary>
   public static class IconSetter
   {
      #region Public Methods

      /// <summary>Sets the programs icon.</summary>
      public static void SetProgramsIcon()
      {
         try
         {
            var iconSourcePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "darts.ico");

            if (!File.Exists(iconSourcePath))
               return;

            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyDescription = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(executingAssembly, typeof(AssemblyDescriptionAttribute)))?.Description;

            var uninstallRootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            var uninstallSubKeys = uninstallRootKey.GetSubKeyNames();

            for (int i = 0; i < uninstallSubKeys.Length; i++)
            {
               var uninstallKey = uninstallRootKey.OpenSubKey(uninstallSubKeys[i], true);
               var valueDisplayName = uninstallKey.GetValue("DisplayName");
               if (valueDisplayName != null && valueDisplayName.ToString() == assemblyDescription)
               {
                  uninstallKey.SetValue("DisplayIcon", iconSourcePath);
                  break;
               }
            }
         }
         catch (Exception ex)
         {
            var logger = LoggerUtils.GetLogger(nameof(IconSetter));
            logger.LogError(ex, ex.Message, ex.StackTrace);
         }
      }

      #endregion Public Methods
   }
}