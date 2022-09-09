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
using ApiConnector.Dto;
using Avalonia.Threading;
using ReactiveUI;

namespace Arce.Admin.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public string Greeting => "Welcome to Avalonia!";
        public ObservableCollection<GameBlockItem> Games { get; } = new();
        public Interaction<GameDataViewModel, GameDataResultViewModel?> ShowDialog { get; }
        public ICommand RefreshCommand { get; set; }
        public ICommand NewCommand { get; set; }




        public MainWindowViewModel() {
            ShowDialog = new Interaction<GameDataViewModel, GameDataResultViewModel?>();
            ReloadGamesDto();

            RefreshCommand = ReactiveCommand.CreateFromTask(async () => {
                await Dispatcher.UIThread.InvokeAsync(() => ReloadGamesDto());
            });
            NewCommand = ReactiveCommand.CreateFromTask(async () => {
                var result = await ShowDialog.Handle(new GameDataViewModel() {
                    Game = new GameDto(),
                    IsNewGame = true
                });
            });

        }

        public void ReloadGamesDto() {
            var gameDtos = (ApiConnector.ApiConnector.Instance.GetGames().GetAwaiter().GetResult())
                ?? new List<GameDto>();

            Games.Clear();
            
            gameDtos.ForEach((gameDto) => {
                Games.Add(new() {
                    Id = gameDto.Id,
                    Name = gameDto.Name,
                    ClickCommand = ReactiveCommand.CreateFromTask(async () => {
                        var result = await ShowDialog.Handle(new GameDataViewModel() {
                            Game = gameDto
                        });
                    }),
                    DeleteCommand = ReactiveCommand.CreateFromTask(async () => {
                        await ApiConnector.ApiConnector.Instance.DeleteGame(gameDto.Id);
                    })
                });
            });
        }
    }
}
