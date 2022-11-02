using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordReplacerApp.Models;
using WordReplacerApp.ViewModels;
using WordReplacerApp.Word;
using Document = WordReplacerApp.Models.Document;
using Task = System.Threading.Tasks.Task;

namespace WordReplacerApp.Commands
{
    public class FindAndReplaceCommand : AsyncCommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private Progress<ProgressReport> _progress = new Progress<ProgressReport>();

        public FindAndReplaceCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _progress.ProgressChanged += ReportProgress;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _mainViewModel.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await FindAndReplace(_progress, _mainViewModel.CancellationTokenSource.Token);

            }
            catch (OperationCanceledException)
            {

            }
        }

        private async Task FindAndReplace(IProgress<ProgressReport> progress, CancellationToken cancellationToken)
        {
            List<ReplaceText> replaceTexts = _mainViewModel.ReplaceTextList
                                .Where(x => !string.IsNullOrEmpty(x.FromText) && !string.IsNullOrWhiteSpace(x.FromText))
                                .GroupBy(x => x.FromText)
                                .Select(x => x.First())
                                //.DistinctBy(x => x.FromText)
                                .ToList();

            List<Document> documents = _mainViewModel.DocumentList.ToList();

            var progressReport = new ProgressReport();
            int i = 0;
            progress.Report(progressReport);

            foreach (var document in documents)
            {
                await Task.Run(() =>
                {
                    string docPath = document.FullPath;
                    string fileName = Path.GetFileNameWithoutExtension(docPath);
                    string savePath = Path.Combine(_mainViewModel.SavePath, $"{fileName}_{DateTime.Now.ToString("dd/MM/yyyy")}.docx");

                    var wordReplacer = new WordReplacer(docPath, savePath);
                    wordReplacer.FindAndReplace(replaceTexts);
                    if (_mainViewModel.DateChange)
                    {
                        wordReplacer.FindAndReplaceDate(_mainViewModel.SelectedDate.Value);
                    }
                    wordReplacer.CreateWordDocument();
                });
                progressReport.PercentageComplete = ((++i) * 100) / documents.Count;
                progress.Report(progressReport);

                cancellationToken.ThrowIfCancellationRequested();
            }
        }
        private void ReportProgress(object sender, ProgressReport e)
        {
            _mainViewModel.ProgressBarValue = e.PercentageComplete;
        }

    }
}
