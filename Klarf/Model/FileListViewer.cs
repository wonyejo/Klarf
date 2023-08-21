using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Forms;



namespace Klarf.Model
{
    class FileListViewer
    {
        public ObservableCollection<string> Files { get; set; }

        public FileListViewer()
        {
            Files = new ObservableCollection<string>();
            // 파일 로드 로직을 여기에 추가합니다.
            
        }

        private void OpenFolder()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // 시작 폴더 설정

            DialogResult result = folderBrowserDialog.ShowDialog(); // 폴더 대화상자 열기

            if (result == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath; // 선택된 폴더의 경로

                // 선택된 폴더를 처리하는 로직을 여기에 추가합니다.
            }

        }
    }
}
