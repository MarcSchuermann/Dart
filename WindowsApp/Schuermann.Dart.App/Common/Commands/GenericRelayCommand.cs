// -----------------------------------------------------------------------
// <copyright file="GenericRelayCommand.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace Dart.Common.Commands
{
    /// <summary>The GenericRelayCommand.</summary>
    /// <typeparam name="T">The parameter T.</typeparam>
    /// <seealso cref="ICommand" />
    public class GenericRelayCommand<T> : ICommand
    {
        #region Private Fields

        /// <summary>The can execute.</summary>
        private readonly Func<bool> canExecute;

        /// <summary>The execute.</summary>
        private readonly Action<T> execute;

        private readonly Action raiseCanExecuteChangedAction;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="GenericRelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public GenericRelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="GenericRelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The action to execute.</param>
        /// <param name="canExecute">The can execute function.</param>
        public GenericRelayCommand(Action<T> execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;

            raiseCanExecuteChangedAction = RaiseCanExecuteChanged;
            SimpleCommandManager.AddRaiseCanExecuteChangedAction(ref raiseCanExecuteChangedAction);
        }

        #endregion Public Constructors

        #region Private Destructors

        /// <summary>
        ///    Finalizes an instance of the <see cref="GenericRelayCommand{T}" /> class.
        /// </summary>
        ~GenericRelayCommand()
        {
            RemoveCommand();
        }

        #endregion Private Destructors

        #region Public Events

        /// <summary>
        ///    Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///    Defines the method that determines whether the command can execute in its current
        ///    state.
        /// </summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                execute((T)parameter);
        }

        /// <summary>Raises the can execute changed.</summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>Removes the command.</summary>
        public void RemoveCommand()
        {
            SimpleCommandManager.RemoveRaiseCanExecuteChangedAction(raiseCanExecuteChangedAction);
        }

        #endregion Public Methods
    }
}