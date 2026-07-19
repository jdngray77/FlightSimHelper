using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.Services.Navigation;

namespace MSFSHelper.Core.ViewModels.Checklist;

[ObservableObject]
public partial class ChecklistGroupViewModel
{
    public string Name { get; }
    public ObservableCollection<ChecklistViewModel> Checklists { get; }

    public ChecklistGroupViewModel(ChecklistGroup group, FSUIPC.FSUIPC ipc)
    {
        Name = group.Name;
        Checklists = new ObservableCollection<ChecklistViewModel>(
            group.Checklists.Select(c => new ChecklistViewModel(c.Name, c, ipc)));
    }
}
