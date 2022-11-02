using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Word;
using WordReplacerApp.Models;

namespace WordReplacerApp.Word
{
    public class WordReplacer
    {
        private Microsoft.Office.Interop.Word.Application _wordApp;
        private Microsoft.Office.Interop.Word.Document _aDoc;
        private object missing = System.Reflection.Missing.Value;
        private object _docPath;
        private object _savePath;

        public WordReplacer(string documentPath, string savePath)
        {
            _savePath = savePath;
            _docPath = documentPath;

            var fileInfo = new System.IO.FileInfo((string)_docPath);
            if (fileInfo.Extension.Contains("doc") && File.Exists((string)_docPath))
            {
                try
                {
                    object readOnly = false;
                    _wordApp = new Microsoft.Office.Interop.Word.Application();
                    _wordApp.Visible = false;
                    _wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

                    _aDoc = _wordApp.Documents.Open(ref _docPath, ref missing, ref readOnly,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing);

                    _aDoc.Activate();
                }
                catch (Exception)
                {
                    _aDoc = null;
                    this._wordApp = null;
                }
            }
            else
            {
                _aDoc = null;
            }

        }

        public void CreateWordDocument()
        {
            _aDoc.SaveAs2(ref _savePath, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);

            _aDoc.Close(ref missing, ref missing, ref missing);
            _wordApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_wordApp);
        }

        public void FindAndReplaceDate(DateTime newDate)
        {
            Find findObject = _wordApp.Selection.Find;
            findObject.ClearFormatting();
            findObject.MatchWildcards = true;
            findObject.Text = "<[0-9]{2}.[0-9]{2}.[0-9]{4}>";

            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = newDate.ToString("dd.MM.yyyy");

            object replaceAll = WdReplace.wdReplaceAll;
            findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll,
                ref missing, ref missing, ref missing, ref missing);
        }

        public void FindAndReplace(IEnumerable<ReplaceText> replaceTexts)
        {
            foreach (var replaceText in replaceTexts)
            {
                string findText = replaceText.FromText;
                string replaceWithText = replaceText.ToText;

                Find findObject = _wordApp.Selection.Find;
                findObject.ClearFormatting();
                findObject.Text = findText;
                findObject.Replacement.ClearFormatting();
                findObject.Replacement.Text = replaceWithText;
                object replaceAll = WdReplace.wdReplaceAll;
                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll,
                    ref missing, ref missing, ref missing, ref missing);

                var shapes = _aDoc.Shapes;
                foreach (Shape shape in shapes)
                {
                    if (shape.TextFrame.HasText != 0)
                    {
                        var initialText = shape.TextFrame.TextRange.Text;
                        var resultingText = initialText.Replace(findText, replaceWithText);
                        if (initialText != resultingText)
                        {
                            shape.TextFrame.TextRange.Text = resultingText;
                        }
                    }
                }
            }
        }
    }
}
