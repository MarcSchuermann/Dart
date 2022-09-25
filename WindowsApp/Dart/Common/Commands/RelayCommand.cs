// -----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace Dart.Common.Commands
{
    /// <summary>The relay command.</summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand<T> : ICommand
    {
        #region Private Fields

        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="RelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public RelayCommand(Action<T> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="RelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        ///    Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///    Defines the method that determines whether the command can execute in its current
        ///    state.
        /// </summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to <see langword="null" />.
        /// </param>
        /// <returns>
        ///    <see langword="true" /> if this command can be executed; otherwise, <see
        ///    langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to <see langword="null" />.
        /// </param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion Public Methods
    }

    /// <summary></summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        #region Private Fields

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public RelayCommand(Action<object> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion Public Constructors

        #region Public Events

        // Ensures WPF commanding infrastructure asks all RelayCommand objects whether their
        // associated views should be enabled whenever a command is invoked
        /// <summary>
        ///    Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        #endregion Public Events

        #region Private Events

        private event EventHandler CanExecuteChangedInternal;

        #endregion Private Events

        #region Public Methods

        /// <summary>
        ///    Defines the method that determines whether the command can execute in its current
        ///    state.
        /// </summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to <see langword="null" />.
        /// </param>
        /// <returns>
        ///    <see langword="true" /> if this command can be executed; otherwise, <see
        ///    langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">
        ///    Data used by the command. If the command does not require data to be passed, this
        ///    object can be set to <see langword="null" />.
        /// </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>Raises the can execute changed.</summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChangedInternal.Raise(this);
        }

        #endregion Public Methods
    }
}