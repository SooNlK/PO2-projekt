using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PO2_projekt.ViewModels;
using PO2_projekt.Views;

namespace PO2_projekt;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
        {
            return null;
        }
        
        var viewname = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);
        var type = Type.GetType(viewname);

        if (type is null)
        {
            return null;
        }
        
        var control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = data;
        return control;
    }

    public bool Match(object? data) => data is ViewModelBase;
}