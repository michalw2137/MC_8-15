﻿using System;
using System.Windows.Input;

namespace Presentation.ViewModel.MVVMcore
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action _canBeExecuteAction;
        private readonly Func<bool>? _canBeFunctionExecute;

        internal void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            if (_canBeFunctionExecute == null)
            {
                return true;
            }
            else
            {
                return _canBeFunctionExecute();
            }
        }

        public void Execute(object? parameter)
        {
            _canBeExecuteAction();
        }

        public RelayCommand(Action action, Func<bool>? function = null)
        {
            _canBeExecuteAction = action ?? throw new ArgumentNullException(nameof(action));
            _canBeFunctionExecute = function;
        }
    }
}