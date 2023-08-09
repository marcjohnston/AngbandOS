using AngbandOS.Core;
using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Cthangband;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IConsoleViewPort
{
    private const bool Fullscreen = false;
    private const float StartupMusicVolume = 100;
    private const float StartupSoundVolume = 100;
    public readonly Queue<char> KeyQueue = new Queue<char>();
    public TextBlock[][] Cells = new TextBlock[45][];
    private BackgroundImageEnum _backgroundImage = BackgroundImageEnum.None;
    public Mixer Mixer = new Mixer();
    private string[] coloursMap = new string[32];
    private BackgroundWorker thread = new BackgroundWorker();

    public int ViewPortHeight => 45;
    public int ViewPortWidth => 80;

    int IViewPort.Height => ViewPortHeight;

    int IViewPort.Width => ViewPortWidth;

    public int MaximumKeyQueueLength => 256;

    /// <summary>
    /// Plays a sound
    /// </summary>
    /// <param name="val"> The sound to play </param>
    public void PlaySound(SoundEffectEnum sound)
    {
        Dispatcher.Invoke(new Action(() =>
        {
            if (Mixer.SoundVolume > 0)
            {
                Mixer.Play(sound);
            }
        }));
    }

    public void PlayMusic(MusicTrackEnum musicTrack)
    {
        Dispatcher.Invoke(new Action(() =>
        {
            Mixer.Play(musicTrack);
        }));
    }

    public void Clear()
    {
        Dispatcher.Invoke(new Action(() =>
        {
            if (Mixer.SoundVolume > 0)
            {
                Color backColor = FromHex(coloursMap[(int)ColourEnum.Background]);
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

    private void Print(int row, int col, string text, ColourEnum foreColour, ColourEnum backColour)
    {
        Color foreColor = FromHex(coloursMap[(int)foreColour]);
        Color backColor = FromHex(coloursMap[(int)backColour]);
        foreach (char c in text)
        {
            if (row >= 0 && row < ViewPortHeight && col >= 0 && col < 80)
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

    public void SetBackground(BackgroundImageEnum image)
    {
        Dispatcher.Invoke(new Action(() =>
        {
            //BackgroundImage = image;
        }));
    }

    public bool KeyQueueIsEmpty()
    {
        return KeyQueue.Count == 0;
    }

    public char WaitForKey()
    {
        while (KeyQueue.Count == 0)
        {
            System.Threading.Thread.Sleep(5);
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

        coloursMap[(int)ColourEnum.Background] = "#000000";
        coloursMap[(int)ColourEnum.Black] = "#2F4F4F";
        coloursMap[(int)ColourEnum.Grey] = "#696969";
        coloursMap[(int)ColourEnum.BrightGrey] = "#A9A9A9";
        coloursMap[(int)ColourEnum.Silver] = "#778899";
        coloursMap[(int)ColourEnum.Beige] = "#FFE4B5";
        coloursMap[(int)ColourEnum.BrightBeige] = "#F5F5DC";
        coloursMap[(int)ColourEnum.White] = "#D3D3D3";
        coloursMap[(int)ColourEnum.BrightWhite] = "#FFFFFF";
        coloursMap[(int)ColourEnum.Red] = "#8B0000";
        coloursMap[(int)ColourEnum.BrightRed] = "#FF0000";
        coloursMap[(int)ColourEnum.Copper] = "#D2691E";
        coloursMap[(int)ColourEnum.Orange] = "#FF4500";
        coloursMap[(int)ColourEnum.BrightOrange] = "#FFA500";
        coloursMap[(int)ColourEnum.Brown] = "#8B4513";
        coloursMap[(int)ColourEnum.BrightBrown] = "#DEB887";
        coloursMap[(int)ColourEnum.Gold] = "#FFD700";
        coloursMap[(int)ColourEnum.Yellow] = "#F0E68C";
        coloursMap[(int)ColourEnum.BrightYellow] = "#FFFF00";
        coloursMap[(int)ColourEnum.Chartreuse] = "#9ACD32";
        coloursMap[(int)ColourEnum.BrightChartreuse] = "#7FFF00";
        coloursMap[(int)ColourEnum.Green] = "#006400";
        coloursMap[(int)ColourEnum.BrightGreen] = "#32CD32";
        coloursMap[(int)ColourEnum.Turquoise] = "#00CED1";
        coloursMap[(int)ColourEnum.BrightTurquoise] = "#00FFFF";
        coloursMap[(int)ColourEnum.Blue] = "#0000CD";
        coloursMap[(int)ColourEnum.BrightBlue] = "#00BFFF";
        coloursMap[(int)ColourEnum.Diamond] = "#E0FFFF";
        coloursMap[(int)ColourEnum.Purple] = "#800080";
        coloursMap[(int)ColourEnum.BrightPurple] = "#EE82EE";
        coloursMap[(int)ColourEnum.Pink] = "#FF1493";
        coloursMap[(int)ColourEnum.BrightPink] = "#FF69B4";

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

    protected T? LoadFromJson<T>(string fuzzyResourceName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Get all of the resource names.  We are going to perform a fuzzy lookup.
        string[] actualResourceNames = assembly.GetManifestResourceNames();

        // Now get the actual matching resource names.
        string[] resourceNames = actualResourceNames.Where(_resourceName => _resourceName.EndsWith(fuzzyResourceName, StringComparison.OrdinalIgnoreCase)).ToArray();

        // Load each of those resources.
        foreach (string resourceName in resourceNames)
        {
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string serializedJson = reader.ReadToEnd();
                    T? item = JsonSerializer.Deserialize<T>(serializedJson);
                    return item;
                }
            }
        }

        return default;
    }

    private void Thread_DoWork(object? sender, DoWorkEventArgs e)
    {
        GameServer gameServer = new GameServer();
        string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string saveFilename = Path.Combine(savePath, "My Games\\angbandos.savefile");
        ICorePersistentStorage persistentStorage = new AngbandOS.PersistentStorage.FileSystemPersistentStorage(saveFilename);
        Configuration configuration = new Configuration();

        JsonTown jsonTown = LoadFromJson<JsonTown>("Town.json");
        if (jsonTown == null)
        {
            throw new Exception("The singleton object failed to deserialize.");
        }
        if (jsonTown.Char == null)
        {
            throw new Exception("The Town.Char property failed to deserialize.");
        }
        if (jsonTown.HousePrice == null || jsonTown.Name == null || jsonTown.Stores == null)
        {
            throw new Exception("The Town.HousePrice property failed to deserialize.");
        }
        if (jsonTown.Name == null)
        {
            throw new Exception("The Town.Name property failed to deserialize.");
        }
        if (jsonTown.Stores == null)
        {
            throw new Exception("The Town.StoreNames property failed to deserialize.");
        }
        TownDefinition townDefinition = new TownDefinition()
        {
            Char = jsonTown.Char.Value,
            HousePrice = jsonTown.HousePrice.Value,
            Name = jsonTown.Name,
            Stores = jsonTown.Stores
        };

        configuration.Towns = new TownDefinition[] { townDefinition };

        if (persistentStorage.GameExists())
        {
            gameServer.PlayExistingGame(this, persistentStorage);
        }
        else
        {
            gameServer.PlayNewGame(this, persistentStorage, configuration);
        }
    }

    public BackgroundImageEnum BackgroundImage
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
                case BackgroundImageEnum.Splash:
                    uri = new Uri("Backgrounds/splash.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Normal:
                    uri = new Uri("Backgrounds/Default.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Overhead:
                    uri = new Uri("Backgrounds/InGame.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Paper:
                    uri = new Uri("Backgrounds/Paper.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Menu:
                    uri = new Uri("Backgrounds/Menu.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Options:
                    uri = new Uri("Backgrounds/Options.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Tomb:
                    uri = new Uri("Backgrounds/Tomb.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Crown:
                    uri = new Uri("Backgrounds/Crown.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Sunset:
                    uri = new Uri("Backgrounds/Sunset.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.Map:
                    uri = new Uri("Backgrounds/Map.png", UriKind.Relative);
                    bitmapImage.UriSource = uri;
                    break;

                case BackgroundImageEnum.WildMap:
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
        BackgroundImage = BackgroundImageEnum.Menu;
        Content = null;
        UniformGrid grid = new UniformGrid();
        AddChild(grid);
        grid.Rows = ViewPortHeight;
        grid.Columns = ViewPortWidth;
        grid.Background = null;
        grid.IsHitTestVisible = false;
        grid.IsEnabled = false;
        grid.Cursor = Cursors.None;
        FontFamily family = new FontFamily("Courier New");
        Cells = new TextBlock[ViewPortHeight][];
        for (int row = 0; row < ViewPortHeight; row++)
        {
            Cells[row] = new TextBlock[ViewPortWidth];
            for (int col = 0; col < ViewPortWidth; col++)
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
                e.Handled = true;
                KeyQueue.Enqueue('\x09');
                break;

            case Key.Return:
                e.Handled = true;
                KeyQueue.Enqueue('\x0D');
                break;

            case Key.Prior:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('9');
                break;

            case Key.Next:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('3');
                break;

            case Key.End:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('1');
                break;

            case Key.Home:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('7');
                break;

            case Key.Left:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('4');
                break;

            case Key.Up:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('8');
                break;

            case Key.Right:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('6');
                break;

            case Key.Down:
                e.Handled = true;
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    KeyQueue.Enqueue('.');
                }
                KeyQueue.Enqueue('2');
                break;

            case Key.Clear:
                e.Handled = true;
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
        thread.DoWork += Thread_DoWork;
        thread.RunWorkerCompleted += Thread_RunWorkerCompleted;
        thread.RunWorkerAsync();
    }

    private void Thread_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    public void MessagesUpdated()
    {
    }

    public void PlayerDied(string name, string diedFrom, int level)
    {
    }

    public void GoldUpdated(int gold)
    {
    }

    public void CharacterRenamed(string name)
    {
    }

    public void ExperienceLevelChanged(int level)
    {
    }

    public void GameStarted()
    {
    }

    public void GameStopped()
    {
    }

    public void GameExceptionThrown(string message)
    {
    }

    public void GameTimeElapsed()
    {
    }

    public void InputReceived()
    {
    }

    public void MessagesReceived(IGameMessage[] gameMessages)
    {

    }
}
