using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WidgetWeb.Infrastructure.Commands
{
    internal abstract class Command : ICommand //Основной класс команд. CanExecute для проверки запуска команды. Execute выполнение команды
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
