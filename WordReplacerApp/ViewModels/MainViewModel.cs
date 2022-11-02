using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WordReplacerApp.Commands;
using WordReplacerApp.Models;

namespace WordReplacerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private ObservableCollection<Document> _documentList = new ObservableCollection<Document>();
        private ObservableCollection<ReplaceText> _replaceTextList = new ObservableCollection<ReplaceText>
        {
            new ReplaceText("STARY", "NOWY"),
        };

        private string _savePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SaveFolder");
        private int _progressBarValue = 0;
        private bool _dateChange = false;
        private DateTime? _selectedDate = DateTime.Now;
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public string SavePath
        {
            get => _savePath;
            set => SetField(ref _savePath, value);
        }
        public Document SelectedDocument { get; set; }
        public ObservableCollection<Document> DocumentList
        {
            get => _documentList;
        }

        public ObservableCollection<ReplaceText> ReplaceTextList
        {
            get => _replaceTextList;
        }
        public ObservableCollection<ReplaceText> SelectedItems { get; } = new ObservableCollection<ReplaceText>();
        public ReplaceText SelectedItem { get; set; }
        public int ProgressBarValue { get => _progressBarValue; set => SetField(ref _progressBarValue, value); }
        public bool DateChange { get => _dateChange; set => SetField(ref _dateChange, value); }
        public DateTime? SelectedDate { get => _selectedDate; set => SetField(ref _selectedDate, value); }

        public ICommand AddFile { get; set; }
        public ICommand DeleteFile { get; set; }
        public ICommand ChangeSavePath { get; set; }
        public ICommand FindAndReplace { get; set; }
        public ICommand UpdateListBox { get; set;  }
        public ICommand StopProcessing { get; set; }
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            AddFile = new AddFileCommand(this, _dialogService);
            DeleteFile = new DeleteFileCommand(this);
            ChangeSavePath = new ChangeSavePathCommand(this, _dialogService);
            FindAndReplace = new FindAndReplaceCommand(this);
            UpdateListBox = new UpdateListBoxCommand(this);
            StopProcessing = new RelayCommand(StopProcessingDocuments);
        }

        private void StopProcessingDocuments()
        {
            CancellationTokenSource.Cancel();
        }
    }
}
