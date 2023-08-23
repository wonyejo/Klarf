using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using Klarf.Model;


namespace Klarf.ViewModel
{
    class WaferMapViewer : INotifyPropertyChanged
    {

        #region 필드
        protected WaferMap waferMap;


        #endregion

        #region 속성
        public WaferMap WaferMap { get; set; }
        #endregion

        #region 생성자
        public WaferMapViewer()
        {
            waferMap = new WaferMap();

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

