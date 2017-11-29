using System;
using System.Windows.Input;

//View Model template that is displayed on the user screen
namespace BlueSheep
{
    public interface ISensorViewModel
    {
        string Title { get; }
        ICommand Toggle { get; }
        string ValueName { get; }
        string Value { get; }
        string ToggleText { get; }
        string Time { get; }
        string Log { get; }
    }
}
