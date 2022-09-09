using Arce.Admin.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace Arce.Admin.Views {
    public partial class GameDataWindow : ReactiveWindow<GameDataViewModel> {
        public GameDataWindow() {
            InitializeComponent();
#if DEBUG
            //this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.SaveCommand.Subscribe(Close)));
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
