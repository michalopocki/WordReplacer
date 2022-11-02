using CommunityToolkit.Mvvm.Messaging;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReplacerApp.Models;
using WordReplacerApp.ViewModels;

namespace WordReplacerApp.Commands
{
    public class AddFileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IDialogService _dialogService;

        public AddFileCommand(MainViewModel mainViewModel, IDialogService dialogService)
        {
            _mainViewModel = mainViewModel;
            _dialogService = dialogService;
        }
        public override void Execute(object parameter)
        {
            LoadFiles();
        }

        private void LoadFiles()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "Load Word Document",
                Filter = @"File (.docx ,.doc)|*.docx;*.doc",
                FilterIndex = 2,
                Multiselect = true,
            };

            bool? dialogResult = _dialogService.ShowOpenFileDialog(_mainViewModel, settings);


            if (dialogResult.HasValue && dialogResult.Value)
            {
                foreach (var path in settings.FileNames)
                {
                    string filename = Path.GetFileName(path);
                    bool findSimilar = false;

                    foreach (var item in _mainViewModel.DocumentList)
                    {
                        if(path == item.FullPath)
                        {
                            findSimilar = true;
                        }
                    }
                    if (findSimilar == false)
                    {
                        _mainViewModel.DocumentList.Add(new Document(filename, path));
                    }
                }
            }
        }
    }
}
