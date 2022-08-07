using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EveryDayNote.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        #region Fields
        private object _currentView;
        #endregion

        #region Properties
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand CloseAppCommand { get; set; }
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand LogginCommand { get; set; }
        public RelayCommand RegCommand { get; set; }
        #endregion

        #region Views
        public LogginViewModel LogginViewModel { get; set; }
        public RegViewModel RegViewModel { get; set; }
        public AppViewModel AppViewModel { get; set; }
        #endregion

        public MainViewModel()
        {
            LogginViewModel = new LogginViewModel();
            RegViewModel = new RegViewModel();
            AppViewModel = new AppViewModel();
            CurrentView = LogginViewModel;

            CloseAppCommand = new RelayCommand(o => { Application.Current.Shutdown(); });    
            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }

            });

            LogginCommand = new RelayCommand(o => { CurrentView = AppViewModel; });
            RegCommand = new RelayCommand(o => { CurrentView = RegViewModel; });

        }
    }
}
