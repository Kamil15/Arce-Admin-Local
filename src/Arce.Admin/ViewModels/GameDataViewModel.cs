using ApiConnector.Dto;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Arce.Admin.ViewModels {
    public class GameDataViewModel : ViewModelBase {
        public GameDto Game { get; set; } = default!;
        public bool IsNewGame { get; set; } = false;
        public string GameName {
            get { return Game.Name; }
            set { Game.Name = value; }
        }

        public string GameDescription {
            get { return Game.Description; }
            set { Game.Description = value; }
        }


        public ReactiveCommand<Unit, GameDataResultViewModel> SaveCommand { get; set; }

        public GameDataViewModel() {
            SaveCommand = ReactiveCommand.CreateFromTask(async () => {
                var apicon = ApiConnector.ApiConnector.Instance;
                if(IsNewGame) {
                    await apicon.CreateGame(Game);
                } else {
                    var resp = await apicon.UpdateGame(Game);
                }
                
                return new GameDataResultViewModel();
            });
        }
    }
}
