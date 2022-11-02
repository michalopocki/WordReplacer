using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReplacerApp.Models;
using WordReplacerApp.ViewModels;

namespace WordReplacerApp.Commands
{
    public class UpdateListBoxCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public UpdateListBoxCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            string updateParam = (string)parameter;

            if (updateParam == "Add")
            {
                _mainViewModel.ReplaceTextList.Add(new ReplaceText(string.Empty, string.Empty));
            }
            else if(updateParam == "Delete")
            {
                if(_mainViewModel.SelectedItem != null)
                    _mainViewModel.ReplaceTextList.Remove(_mainViewModel.SelectedItem);
            }
        }
    }
}
