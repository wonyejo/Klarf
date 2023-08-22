using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace Klarf.ViewModel
{
    class FileListViewerVM
    {
        public ObservableCollection<string> Files { get; set; }

        #region 속성
        public ICommand OpenFolder { get; private set; }
        #endregion
        public FileListViewerVM()
        {
            Files = new ObservableCollection<string>();
            // 파일 로드 로직을 여기에 추가합니다.
            OpenFolder = new RelayCommand(OpenFolderExecute);
        }

        public void OpenFolderExecute()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // 시작 폴더 설정

            DialogResult result = folderBrowserDialog.ShowDialog(); // 폴더 대화상자 열기

            if (result == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath; // 선택된 폴더의 경로
                


            }

        }
    }
}
