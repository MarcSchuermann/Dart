// -----------------------------------------------------------------------
// <copyright file="ItemsChangeObservableCollection.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Dart.Common.UserInterface.Helper
{
    /// <summary>The ItemsChangeObservableCollection.</summary>
    /// <typeparam name="T">The T.</typeparam>
    /// <seealso cref="ObservableCollection{T}" />
    public class ItemsChangeObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        #region Protected Methods

        /// <summary>Clears the items.</summary>
        protected override void ClearItems()
        {
            UnRegisterPropertyChanged(this);
            base.ClearItems();
        }

        /// <summary>Raises the <see cref="E:CollectionChanged" /> event.</summary>
        /// <param name="e">
        ///    The <see cref="NotifyCollectionChangedEventArgs" /> instance containing the event
        ///    data.
        /// </param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                RegisterPropertyChanged(e.NewItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                UnRegisterPropertyChanged(e.OldItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                UnRegisterPropertyChanged(e.OldItems);
                RegisterPropertyChanged(e.NewItems);
            }

            base.OnCollectionChanged(e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>Handles the PropertyChanged event of the Item control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///    The <see cref="PropertyChangedEventArgs" /> instance containing the event data.
        /// </param>
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>Registers the property changed.</summary>
        /// <param name="items">The items.</param>
        private void RegisterPropertyChanged(IList items)
        {
            foreach (INotifyPropertyChanged item in items)
            {
                if (item != null)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        /// <summary>Use the register property changed.</summary>
        /// <param name="items">The items.</param>
        private void UnRegisterPropertyChanged(IList items)
        {
            foreach (INotifyPropertyChanged item in items)
            {
                if (item != null)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
        }

        #endregion Private Methods
    }
}