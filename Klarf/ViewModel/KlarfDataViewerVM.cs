using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klarf.Model;
using System.Collections.ObjectModel;

namespace Klarf.ViewModel
{
    class KlarfDataViewerVM
    {
        private string filePath;
        public ObservableCollection<KlarfFile> KlarfFiles { get; set; }

        public KlarfDataViewerVM()
        {
            KlarfFiles = new ObservableCollection<KlarfFile>();
        }
      
    }
}
