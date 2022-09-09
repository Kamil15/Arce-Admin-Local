using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arce.Admin.ViewModels {
    public class GameBlockItem : ViewModelBase {
        public long Id { get; init; }
        public string Name { get; set; }

        public ICommand ClickCommand { get; set; }
        public ICommand DeleteCommand { get; set; }




        public GameBlockItem(string Name) : base() {
            this.Name = Name;
        }
        public GameBlockItem() {
            //Id = 0;
            Name = default!;
            ClickCommand = default!;
            DeleteCommand = default!;
        }
    }
}
