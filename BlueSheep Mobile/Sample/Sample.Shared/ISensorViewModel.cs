using System;
using System.Windows.Input;

//View Model template that is displayed on the user screen
namespace Sample
{
    public interface ISensorViewModel
    {
        string Title { get; }
        ICommand Toggle { get; }
        string ValueName { get; }
        string Value { get; }
        string ToggleText { get; }
    }
}
