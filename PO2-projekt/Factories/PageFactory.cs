using System;
using PO2_projekt.Data;
using PO2_projekt.ViewModels;

namespace PO2_projekt.Factories;

public class PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName) => factory.Invoke(pageName);
}