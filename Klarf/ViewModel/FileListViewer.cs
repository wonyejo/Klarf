using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Linq;

namespace Klarf.ViewModel
{
    class FileListViewer : INotifyPropertyChanged
    {
        private string selectedFolderPath;
        public string SelectedFolderPath
        {
            get
            {
                return selectedFolderPath;
            }
            set
            {
                selectedFolderPath = value;
                OnPropertyChanged(nameof(selectedFolderPath));
            }
        }

        private ObservableCollection<KlarfFile> klarfPaths;
        public ObservableCollection<KlarfFile> KlarfPaths
        {
            get
            {
                return klarfPaths;
            }
            set
            {
                klarfPaths = value;
                OnPropertyChanged(nameof(KlarfPaths));
            }
        }

        private RelayCommand _openFolderCommand;
        public ICommand OpenFolderCommand
        {
            get
            {
                return _openFolderCommand ?? (_openFolderCommand = new RelayCommand(OpenFolderDialog));
            }
            set
            {

            }
        }

        public FileListViewer()
        {
            klarfPaths = new ObservableCollection<KlarfFile>();

            OpenFolderCommand = new RelayCommand(OpenFolderDialog);
        }

        private void OpenFolderDialog()
        {
            using (var folderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedFolderPath = folderDialog.SelectedPath;
                    LoadFileList(SelectedFolderPath);
                }
            }
        }

        private void LoadFileList(string folderPath)
        {
            string[] klarfExtensions = { ".001", ".tif" };

            if (Directory.Exists(folderPath))
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    string extension = Path.GetExtension(filePath).ToLower();

                    if (klarfExtensions.Contains(extension))
                    {
                        DateTime updateTime = File.GetLastWriteTime(filePath);
                        klarfPaths.Add(new KlarfFile { Name = Path.GetFileName(filePath), Path = filePath, UpdateTime = updateTime });
                    }
                }
            }
        }

        public class KlarfFile
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public bool IsFolder { get; set; }
            public DateTime UpdateTime { get; set; }
        }

        // ... (INotifyPropertyChanged 및 RelayCommand 관련 코드 생략)
    }
}
