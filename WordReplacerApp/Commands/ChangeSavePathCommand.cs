using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WordReplacerApp.ViewModels;

namespace WordReplacerApp.Commands
{
    public class ChangeSavePathCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IDialogService _dialogService;

        public ChangeSavePathCommand(MainViewModel mainViewModel, IDialogService dialogService)
        {
            _mainViewModel = mainViewModel;
            _dialogService = dialogService;
        }
        public override void Execute(object parameter)
        {
            ChangeSavePath();
        }

        private void ChangeSavePath()
        {
            var settings = new FolderBrowserDialogSettings
            {
                Description = "Wybierz folder do zapisu dokumentów .docx",
                SelectedPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };

            bool? success = _dialogService.ShowFolderBrowserDialog(_mainViewModel, settings);
            if (success == true & !string.IsNullOrWhiteSpace(settings.SelectedPath))
            {
                _mainViewModel.SavePath = settings.SelectedPath;
            }
        }
    }
}
