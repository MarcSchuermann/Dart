//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.App.Common.UserInterface.Converter;
using Schuermann.Dart.App.Common.UserInterface.Helper;
using Schuermann.Dart.App.Game.UserInterface.ViewModels;

namespace UnitTests.Game.UserInterface.Converter.ListToVisibilityConverterTests
{
   /// <summary>The convert test.</summary>
   [TestClass]
   [ExcludeFromCodeCoverage]
   public class ConvertTests
   {
      #region Public Methods

      /// <summary>Converts to hidden via empty player list.</summary>
      [TestMethod]
      public void ConvertToHiddenViaEmptyPlayerlist()
      {
         var converter = new ListToVisibilityConverter();

         var playerList = new ItemsChangeObservableCollection<PlayerViewModel>();

         Assert.AreEqual(Visibility.Hidden, converter.Convert(playerList, null, null, null));
      }

      /// <summary>Converts to hidden via not initialized player list.</summary>
      [TestMethod]
      public void ConvertToHiddenViaNotInitializedPlayerlist()
      {
         var converter = new ListToVisibilityConverter();

         Assert.AreEqual(Visibility.Hidden, converter.Convert(null, null, null, null));
      }

      /// <summary>Converts to visible.</summary>
      [TestMethod]
      public void ConvertToVisible()
      {
         var converter = new ListToVisibilityConverter();

         var playerList = new ItemsChangeObservableCollection<PlayerViewModel>
            {
                new PlayerViewModel("Willy"),
                new PlayerViewModel("Herbert")
            };

         Assert.AreEqual(Visibility.Visible, converter.Convert(playerList, null, null, null));
      }

      #endregion Public Methods
   }
}