using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace Klarf.ViewModel
{
    class WaferMapViewerVM : INotifyPropertyChanged
    {

        #region 필드
        private string waferImgSrc;

        public string WaferImgSrc
        {
            get { return waferImgSrc; }
            set
            {
                waferImgSrc = value;
                OnPropertyChanged(nameof(WaferImgSrc));
            }
        }
        #endregion

        #region 속성
   
         #endregion

        #region 생성자
        public WaferMapViewerVM()
        {
           

        }
        #endregion

        #region 메서드
    

       

     
    }

    #endregion

    #region 중첩된 클래스

    public abstract class INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion

}

