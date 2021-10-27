using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp7.Annotations;

namespace WpfApp7 {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        protected string downUp;
        protected string keyCode, keyChar, systemKey;
        protected int keyValue;
        protected string keyState;

        public string DownUp {
            get => downUp;
            set {
                downUp = value;
                OnPropertyChanged(nameof(DownUp));
            }
        }

        public string KeyCode {
            get => keyCode;
            set {
                keyCode = value;
                OnPropertyChanged(nameof(KeyCode));
            }
        }

        public int KeyValue {
            get => keyValue;
            set {
                keyValue = value;
                OnPropertyChanged(nameof(KeyValue));
            }
        }

        public string KeyState {
            get => keyState;
            set {
                keyState = value;
                OnPropertyChanged(nameof(KeyState));
            }
        }

        public string KeyChar {
            get => keyChar;
            set {
                keyChar = value;
                OnPropertyChanged(nameof(KeyChar));
            }
        }

        public string SystemKey
        {
            get => systemKey;
            set {
                systemKey = value;
                OnPropertyChanged(nameof(SystemKey));
            }
        }
        public MainWindow( ) {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e) {
            DownUpKey.Binding.BindingGroupName = e.IsDown.ToString();
            KeyCode = e.Key.ToString();
            KeyValue = int.Parse(e.Key.ToString());
            KeyState = e.KeyStates.ToString();
            KeyChar = e.DeadCharProcessedKey.ToString();
            SystemKey = e.SystemKey.ToString();
        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e) {
            DownUp = e.IsUp.ToString();
            KeyCode = e.Key.ToString();
            KeyValue = int.Parse(e.Key.ToString());
            KeyState = e.KeyStates.ToString();
            KeyChar = e.DeadCharProcessedKey.ToString();
            SystemKey = e.SystemKey.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
