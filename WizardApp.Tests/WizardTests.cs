using WizardApp.ViewModels;
using Xunit;

public class WizardTests
{
    [Fact]
    public void Navigation_EnablesAndDisablesCommands()
    {
        var vm = new MainViewModel();
        Assert.False(vm.PreviousCommand.CanExecute(null));
        Assert.True(vm.NextCommand.CanExecute(null));
        Assert.IsType<ControlAViewModel>(vm.CurrentViewModel);
        vm.NextCommand.Execute(null);
        Assert.IsType<ControlBViewModel>(vm.CurrentViewModel);
        vm.NextCommand.Execute(null);
        Assert.IsType<ControlCViewModel>(vm.CurrentViewModel);
        Assert.False(vm.NextCommand.CanExecute(null));
        Assert.True(vm.PreviousCommand.CanExecute(null));
        Assert.Equal("Step 3 of 3", vm.StepText);
        vm.PreviousCommand.Execute(null);
        Assert.IsType<ControlBViewModel>(vm.CurrentViewModel);
    }

    [Fact]
    public void Navigation_RaisesPropertyChanged()
    {
        var vm = new MainViewModel();
        var changed = new List<string?>();
        vm.PropertyChanged += (_, e) => changed.Add(e.PropertyName);
        vm.NextCommand.Execute(null);
        Assert.Contains("CurrentViewModel", changed);
    }

    [Fact]
    public void Grid_Has50Rows_AndTree_Filters()
    {
        Assert.Equal(50, new ControlBViewModel().Items.Count);
        var a = new ControlAViewModel();
        a.SearchText = "Alice";
        Assert.Single(a.Nodes);
        Assert.Contains("Alice", a.Nodes[0].Children[0].Children[0].Children[0].Name);
        a.SearchText = "";
        Assert.Equal(4, a.Nodes[0].Children.Count);
    }

    [Fact]
    public void Form_Validates()
    {
        var f = new ControlCViewModel().Form;
        Assert.False(f.IsValid);
        f.FirstName = "A"; f.LastName = "B"; f.Department = "Sales";
        f.Options[1].IsChecked = true;
        Assert.True(f.IsValid);
    }
}
