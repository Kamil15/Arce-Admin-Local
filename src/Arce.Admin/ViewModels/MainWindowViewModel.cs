using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace Arce.Admin.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public string Greeting => "Welcome to Avalonia!";
        public ObservableCollection<GameBlockItem> Games { get; } = new();
        public Interaction<GameDataViewModel, GameDataResultViewModel?> ShowDialog { get; }

        public MainWindowViewModel() {
            ShowDialog = new Interaction<GameDataViewModel, GameDataResultViewModel?>();

            Games.Add(new() {
                Id = 1,
                Name = "ard",
                ClickCommand = ReactiveCommand.CreateFromTask(async () => {
                    var result = await ShowDialog.Handle(new GameDataViewModel());
                })
            });

            Games.Add(new() { Id = 2, Name = "aba" });
            Games.Add(new() { Id = 3, Name = "aab" });
            Games.Add(new() { Id = 4, Name = "aca" });

        }
    }
}
