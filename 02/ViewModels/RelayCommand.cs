using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rocnikovka_first.ViewModels
{
    /// <summary>
    /// Jednoduchá implementace ICommand.
    /// Umožňuje navázat tlačítko v XAML na libovolnou akci ve ViewModelu.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        /// <summary>
        /// Vytvoří nový příkaz.
        /// </summary>
        /// <param name="execute">Akce, která se má vykonat.</param>
        /// <param name="canExecute">Volitelná funkce, která rozhoduje, zda je příkaz povolen.</param>
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) =>
            _execute(parameter);

        /// <summary>
        /// Vyvolá znovu vyhodnocení CanExecute (pro např. povolení/zakázání tlačítek).
        /// </summary>
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
