using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WidgetWeb.Infrastructure.Commands
{
    internal class ExitCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
