// -----------------------------------------------------------------------
// <copyright file="DevelopmentPropertiesView.xaml.cs" company="Marc Schürmann">
// Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>

using Dart.Common.UserInterface.Helper;
using System.Runtime.InteropServices;
using System.Windows;

namespace Dart.Tools
{
    /// <summary>Interaction logic for DartBoardData.</summary>
    [ComVisible(false)]
    public partial class DevelopmentPropertiesView : Window
    {
      private readonly IThrowInfo throwInfo;
      #region Public Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="DevelopmentPropertiesView"/> class.
      /// </summary>
      public DevelopmentPropertiesView(IThrowInfo throwInfo)
        {
            InitializeComponent();
         this.throwInfo = throwInfo;

         FillData();
      }

      public void FillData()
      {
         list.Items.Clear();

         if (throwInfo == null)
            return;

         foreach (var prop in throwInfo.GetType().GetProperties())
         {
            list.Items.Add(new { Name = prop.Name, Value = prop.GetValue(throwInfo)?.ToString() ?? "null" });
         }
      }

        #endregion Public Constructors
    }
}