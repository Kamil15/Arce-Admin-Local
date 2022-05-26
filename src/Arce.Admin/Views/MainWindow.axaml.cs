using Arce.Admin.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace Arce.Admin.Views {
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }

        private async Task DoShowDialogAsync(InteractionContext<GameDataViewModel, GameDataResultViewModel?> interaction) {
            var dialog = new GameDataWindow {
                DataContext = interaction.Input
            };
            

            var result = await dialog.ShowDialog<GameDataResultViewModel?>(this);
            interaction.SetOutput(result);
        }
    }
}