using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Linq;
using Klarf.Model;

namespace Klarf.ViewModel
{
    class FileListViewerVM : INotifyPropertyChanged
    {

        #region 필드
        private string selectedFile;
        private string selectedFolderPath;
        private RelayCommand _openFolderCommand;

        #endregion

        #region 속성
        public string SelectedFile
        {
            get
            {
                return selectedFile;
            }
            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;
                    OnPropertyChanged("SelectedFile");

                    if (selectedFile != null)
                    {
                        KlarfDataReader klarfDataReader;
                        klarfDataReader = new KlarfDataReader(selectedFolderPath + selectedFile); //읽고 처리까진 됐을 거임
                        
                    }
                }
            }
        }
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
        #endregion
        #region 생성자
        public FileListViewerVM()
        {
            klarfPaths = new ObservableCollection<KlarfFile>();

            OpenFolderCommand = new RelayCommand(OpenFolderDialog);
        }
        #endregion

        #region 메서드
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



        // ... (INotifyPropertyChanged 및 RelayCommand 관련 코드 생략)
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    #endregion
    #region 중첩된 클래스

    #endregion









}
