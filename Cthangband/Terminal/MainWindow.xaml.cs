// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cthangband.Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : System.Windows.Window, IConsole
    {
        private const bool Fullscreen = false;
        public readonly Queue<char> KeyQueue = new Queue<char>();
        public TextBlock[][] Cells = new TextBlock[45][];
        private BackgroundImage _backgroundImage = BackgroundImage.None;

        public void SetCellBackground(int row, int col, string color)
        {
            if (color == null)
            {
                Cells[row][col].Background = null;
            }
            else
            {
                Cells[row][col].Background = new SolidColorBrush(FromHex(color));
            }
        }

        public void Clear()
        {
            foreach (System.Windows.Controls.TextBlock[] line in Cells)
            {
                foreach (System.Windows.Controls.TextBlock textBlock in line)
                {
                    textBlock.Text = " ";
                }
            }
        }

        public void Print(int row, int col, string text, string colour)
        {
            foreach (char c in text)
            {
                if (row >= 0 && row < Constants.ConsoleHeight && col >= 0 && col < 80)
                {
                    char printable = c;
                    if (printable < 32)
                    {
                        printable = '?';
                    }
                    System.Windows.Controls.TextBlock t = Cells[row][col];
                    t.Foreground = new SolidColorBrush(FromHex(colour));
                    t.Text = printable.ToString();
                    col++;
                }
            }
        }

        public void SetBackground(BackgroundImage image)
        {
            BackgroundImage = image;
        }

        public char WaitForKey()
        {
            while (KeyQueue.Count == 0)
            {
                System.Windows.Forms.Application.DoEvents();
                if (KeyQueue.Count == 0)
                {
                    System.Threading.Thread.Sleep(5);
                }
            }
            return KeyQueue.Dequeue();
        }

        private System.Windows.Media.Color FromHex(string hex)
        {
            string colorcode = hex;
            int argb = Int32.Parse(colorcode.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
            System.Windows.Media.Color value = System.Windows.Media.Color.FromArgb((byte)((argb & -16777216) >> 0x18), (byte)((argb & 0xff0000) >> 0x10), (byte)((argb & 0xff00) >> 8), (byte)(argb & 0xff));
            return value;
        }

        public MainWindow()
        {
            InitializeComponent();
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
            ElementHost.EnableModelessKeyboardInterop(this);
            Visibility = Visibility.Visible;
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
            grid.Rows = Constants.ConsoleHeight;
            grid.Columns = Constants.ConsoleWidth;
            grid.Background = null;
            grid.IsHitTestVisible = false;
            grid.IsEnabled = false;
            grid.Cursor = Cursors.None;
            FontFamily family = new FontFamily("Courier New");
            Cells = new TextBlock[Constants.ConsoleHeight][];
            for (int row = 0; row < Constants.ConsoleHeight; row++)
            {
                Cells[row] = new TextBlock[Constants.ConsoleWidth];
                for (int col = 0; col < Constants.ConsoleWidth; col++)
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

                case Key.Escape:
                    KeyQueue.Enqueue('\x1B');
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

    }
}