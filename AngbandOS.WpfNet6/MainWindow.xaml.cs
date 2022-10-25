using AngbandOS;
using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IConsole
    {
        private const int ConsoleWidth = 80;
        private const int ConsoleHeight = 45;
        private const bool Fullscreen = false;
        private const float StartupMusicVolume = 100;
        private const float StartupSoundVolume = 100;
        public readonly Queue<char> KeyQueue = new Queue<char>();
        public TextBlock[][] Cells = new TextBlock[45][];
        private BackgroundImage _backgroundImage = BackgroundImage.None;
        public Mixer Mixer = new Mixer();
        private string[] coloursMap = new string[32];
        private BackgroundWorker thread = new BackgroundWorker();

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="val"> The sound to play </param>
        public void PlaySound(SoundEffect sound)
        {
            Dispatcher.Invoke(new Action(() => {
                if (Mixer.SoundVolume > 0)
                {
                    Mixer.Play(sound);
                }
            }));
        }

        public void PlayMusic(MusicTrack musicTrack)
        {
            Dispatcher.Invoke(new Action(() => {
                Mixer.Play(musicTrack);
            }));
        }

        public void Clear()
        {
            Dispatcher.Invoke(new Action(() => {
                if (Mixer.SoundVolume > 0)
                {
                    Color backColor = FromHex(coloursMap[(int)Colour.Background]);
                    foreach (TextBlock[] line in Cells)
                    {
                        foreach (TextBlock textBlock in line)
                        {
                            textBlock.Text = " ";
                            textBlock.Background = new SolidColorBrush(backColor);
                        }
                    }
                }
            }));
        }

        public void BatchPrint(PrintLine[] printLines)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                foreach (PrintLine printLine in printLines)
                    Print(printLine.row, printLine.col, printLine.text, printLine.foreColour, printLine.backColour);
            }));
        }

        private void Print(int row, int col, string text, Colour foreColour, Colour backColour)
        {
            Color foreColor = FromHex(coloursMap[(int)foreColour]);
            Color backColor = FromHex(coloursMap[(int)backColour]);
            foreach (char c in text)
            {
                if (row >= 0 && row < ConsoleHeight && col >= 0 && col < 80)
                {
                    char printable = c;
                    if (printable < 32)
                    {
                        printable = '?';
                    }
                    TextBlock t = Cells[row][col];
                    t.Foreground = new SolidColorBrush(foreColor);
                    t.Background = new SolidColorBrush(backColor);
                    t.Text = printable.ToString();
                    col++;
                }
            }
        }

        public void SetBackground(BackgroundImage image)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                //BackgroundImage = image;
            }));
        }

        public char WaitForKey()
        {
            while (KeyQueue.Count == 0)
            {
                if (KeyQueue.Count == 0)
                {
                    System.Threading.Thread.Sleep(5);
                }
            }
            char key = KeyQueue.Dequeue();
            return key;
        }

        private Color FromHex(string hex)
        {
            string colorcode = hex;
            int argb = Int32.Parse(colorcode.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
            byte a = (byte)((argb & -16777216) >> 0x18);
            a = 255;
            byte r = (byte)((argb & 0xff0000) >> 0x10);
            byte g = (byte)((argb & 0xff00) >> 8);
            byte b = (byte)(argb & 0xff);
            Color value = Color.FromArgb(a, r, g, b);
            return value;
        }

        public MainWindow()
        {
            InitializeComponent();

            coloursMap[(int)Colour.Background] = "#000000";
            coloursMap[(int)Colour.Black] = "#2F4F4F";
            coloursMap[(int)Colour.Grey] = "#696969";
            coloursMap[(int)Colour.BrightGrey] = "#A9A9A9";
            coloursMap[(int)Colour.Silver] = "#778899";
            coloursMap[(int)Colour.Beige] = "#FFE4B5";
            coloursMap[(int)Colour.BrightBeige] = "#F5F5DC";
            coloursMap[(int)Colour.White] = "#D3D3D3";
            coloursMap[(int)Colour.BrightWhite] = "#FFFFFF";
            coloursMap[(int)Colour.Red] = "#8B0000";
            coloursMap[(int)Colour.BrightRed] = "#FF0000";
            coloursMap[(int)Colour.Copper] = "#D2691E";
            coloursMap[(int)Colour.Orange] = "#FF4500";
            coloursMap[(int)Colour.BrightOrange] = "#FFA500";
            coloursMap[(int)Colour.Brown] = "#8B4513";
            coloursMap[(int)Colour.BrightBrown] = "#DEB887";
            coloursMap[(int)Colour.Gold] = "#FFD700";
            coloursMap[(int)Colour.Yellow] = "#F0E68C";
            coloursMap[(int)Colour.BrightYellow] = "#FFFF00";
            coloursMap[(int)Colour.Chartreuse] = "#9ACD32";
            coloursMap[(int)Colour.BrightChartreuse] = "#7FFF00";
            coloursMap[(int)Colour.Green] = "#006400";
            coloursMap[(int)Colour.BrightGreen] = "#32CD32";
            coloursMap[(int)Colour.Turquoise] = "#00CED1";
            coloursMap[(int)Colour.BrightTurquoise] = "#00FFFF";
            coloursMap[(int)Colour.Blue] = "#0000CD";
            coloursMap[(int)Colour.BrightBlue] = "#00BFFF";
            coloursMap[(int)Colour.Diamond] = "#E0FFFF";
            coloursMap[(int)Colour.Purple] = "#800080";
            coloursMap[(int)Colour.BrightPurple] = "#EE82EE";
            coloursMap[(int)Colour.Pink] = "#FF1493";
            coloursMap[(int)Colour.BrightPink] = "#FF69B4";

            KeyDown += MainWindow_KeyDown;
            Closing += MainWindow_Closing;
            TextInput += MainWindow_TextInput;
            if (Fullscreen)
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                Width = 1600;
                Height = 900;
            }
            Title = "";
            InitializeGrid();
            Visibility = Visibility.Visible;
            Mixer.Initialise(StartupMusicVolume / 100.0f, StartupSoundVolume / 100.0f);
        }

        private void Thread_DoWork(object? sender, DoWorkEventArgs e)
        {
            GameServer game = new GameServer();
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string saveFilename = Path.Combine(savePath, "My Games\\angbandos.savefile");
            ICorePersistentStorage persistentStorage = new AngbandOS.PersistentStorage.FileSystemPersistentStorage(saveFilename);
            game.Play(this, persistentStorage, null);
        }

        public BackgroundImage BackgroundImage
        {
            set
            {
                if (value == _backgroundImage)
                {
                    return;
                }
                _backgroundImage = value;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                Uri uri;
                switch (value)
                {
                    case BackgroundImage.Splash:
                        uri = new Uri("Backgrounds/splash.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Normal:
                        uri = new Uri("Backgrounds/Default.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Overhead:
                        uri = new Uri("Backgrounds/InGame.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Paper:
                        uri = new Uri("Backgrounds/Paper.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Menu:
                        uri = new Uri("Backgrounds/Menu.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Options:
                        uri = new Uri("Backgrounds/Options.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Tomb:
                        uri = new Uri("Backgrounds/Tomb.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Crown:
                        uri = new Uri("Backgrounds/Crown.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Sunset:
                        uri = new Uri("Backgrounds/Sunset.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.Map:
                        uri = new Uri("Backgrounds/Map.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;

                    case BackgroundImage.WildMap:
                        uri = new Uri("Backgrounds/WildMap.png", UriKind.Relative);
                        bitmapImage.UriSource = uri;
                        break;
                }
                bitmapImage.EndInit();
                Background = new ImageBrush(bitmapImage);
            }
            get => _backgroundImage;
        }

        public void InitializeGrid()
        {
            BackgroundImage = BackgroundImage.Menu;
            Content = null;
            UniformGrid grid = new UniformGrid();
            AddChild(grid);
            grid.Rows = ConsoleHeight;
            grid.Columns = ConsoleWidth;
            grid.Background = null;
            grid.IsHitTestVisible = false;
            grid.IsEnabled = false;
            grid.Cursor = Cursors.None;
            FontFamily family = new FontFamily("Courier New");
            Cells = new TextBlock[ConsoleHeight][];
            for (int row = 0; row < ConsoleHeight; row++)
            {
                Cells[row] = new TextBlock[ConsoleWidth];
                for (int col = 0; col < ConsoleWidth; col++)
                {
                    Viewbox v = new Viewbox();
                    TextBlock x = new TextBlock();
                    v.Stretch = Stretch.Fill;
                    x.FontFamily = family;
                    x.FontWeight = FontWeights.Regular;
                    x.FontStyle = FontStyles.Normal;
                    x.Text = new string(' ', 1);
                    x.Background = null;
                    x.Foreground = Brushes.White;
                    x.IsEnabled = false;
                    grid.Children.Add(v);
                    v.Child = x;
                    Cells[row][col] = x;
                }
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Tab:
                    KeyQueue.Enqueue('\x09');
                    break;

                case Key.Return:
                    KeyQueue.Enqueue('\x0D');
                    break;

                case Key.Prior:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('9');
                    break;

                case Key.Next:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('3');
                    break;

                case Key.End:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('1');
                    break;

                case Key.Home:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('7');
                    break;

                case Key.Left:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('4');
                    break;

                case Key.Up:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('8');
                    break;

                case Key.Right:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('6');
                    break;

                case Key.Down:
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        KeyQueue.Enqueue('.');
                    }
                    KeyQueue.Enqueue('2');
                    break;

                case Key.Clear:
                    KeyQueue.Enqueue('5');
                    break;

                default:
                    return;
            }
        }

        private void MainWindow_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Text) == false)
            {
                if (e.Text[0] < 255)
                {
                    KeyQueue.Enqueue(e.Text[0]);
                }
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Print(1, 1, "Xena", Colour.Red, Colour.Black);
            thread.DoWork += Thread_DoWork;
            thread.RunWorkerCompleted += Thread_RunWorkerCompleted;
            thread.RunWorkerAsync();
        }

        private void Thread_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
