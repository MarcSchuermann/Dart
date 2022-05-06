// -----------------------------------------------------------------------
// <copyright file="RibbonView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using Schuermann.Darts.Environment.Extensibility;

namespace Dart.Game.UserInterface.Views
{
    /// <summary>Interaction logic for RibbonView.xaml.</summary>
    public partial class RibbonView : UserControl
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="RibbonView" /> class.</summary>
        public RibbonView()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private RibbonApplicationMenuItem Create(IPlugIn plugIn)
        {
            var ribbonApplicationMenuItem = new RibbonApplicationMenuItem() { Header = plugIn.Name };
            ribbonApplicationMenuItem.DataContext = plugIn;
            ribbonApplicationMenuItem.Click += RibbonApplicationMenuItem_Click;
            ribbonApplicationMenuItem.IsEnabled = GetEnabledValue(plugIn);
            return ribbonApplicationMenuItem;
        }

        private void CreateExtensionMenuEntries()
        {
            if (DataContext is ToolBarViewModel toolBarViewModel)
            {
                var plugInsToCreate = toolBarViewModel.OwnerViewModel.PlugIns.OrderBy(x => x.Name);

                foreach (var plugIn in plugInsToCreate)
                {
                    var existingPlugInEntry = ExtensionMenuEntry.Items.Cast<RibbonApplicationMenuItem>().FirstOrDefault(x => (x.DataContext as IPlugIn).Name == plugIn.Name);
                    if (existingPlugInEntry != null)
                        ExtensionMenuEntry.Items.Remove(existingPlugInEntry);

                    ExtensionMenuEntry.Items.Add(Create(plugIn));
                }
            }
        }

        private bool GetEnabledValue(IPlugIn plugIn)
        {
            if (DataContext is ToolBarViewModel toolBarViewModel)
            {
                if (toolBarViewModel.OwnerViewModel.CurrentContent is GameOptionsViewModel gameOptionsViewModel)
                {
                    return plugIn.PlugInCommand.EnabledInMainMenu;
                }

                if (toolBarViewModel.OwnerViewModel.CurrentContent is DartGameViewModel)
                    return plugIn.PlugInCommand.EnabledInGame;
            }

            return true;
        }

        private void RibbonApplicationMenu_DropDownOpened(object sender, EventArgs e)
        {
            CreateExtensionMenuEntries();
        }

        private void RibbonApplicationMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is RibbonApplicationMenuItem menuItem)
            {
                if (menuItem.DataContext is IPlugIn plugIn)
                {
                    if (DataContext is ToolBarViewModel toolBarViewModel)
                    {
                        if (toolBarViewModel.OwnerViewModel.CurrentContent is DartGameViewModel dartGameViewModel)
                        {
                            plugIn.GameOptions = dartGameViewModel.MainWindowViewModel.ConfiguredGameOptions;
                            plugIn.PlugInCommand.OnExecute.Invoke();
                        }
                    }
                }
            }
        }

        #endregion Private Methods
    }
}