using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReplacerApp.ViewModels;

namespace WordReplacerApp.Commands
{
    public class DeleteFileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        public DeleteFileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            string param = (string)parameter;

            if (param == "single")
            {
                if (_mainViewModel.SelectedDocument != null)
                {
                    _mainViewModel.DocumentList.Remove(_mainViewModel.SelectedDocument);
                }
            }
            else if (param == "all")
            {
                _mainViewModel.DocumentList.Clear();
            }
        }
    }
}
