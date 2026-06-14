using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using AngbandOS.Core.Interface;
using AngbandOS.Core;
using System.Threading.Tasks;
using System.IO;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.PersistentStorage.FileSystem;

namespace AngbandOS.Avalonia
{
    public partial class MainWindow : Window, IConsoleAndViewPort
    {
        // Viewport size must match the game minimums used elsewhere.
        public const int ViewPortHeightConst = 45;
        public const int ViewPortWidthConst = 80;

        public readonly Queue<char> KeyQueue = new Queue<char>();
        private TextBlock[][] Cells = new TextBlock[ViewPortHeightConst][];
        private string[] colorsMap = new string[32];

        private BackgroundImageEnum _backgroundImage = BackgroundImageEnum.None;

        // Minimal cross-platform mixer stub for Avalonia front-end.
        // It intentionally provides no-op audio on platforms without System.Media support.
        private readonly Mixer Mixer = new Mixer();

        public MainWindow()
        {
            InitializeComponent();

            // color map copied from WPF app for consistent rendering
            colorsMap[(int)ColorEnum.Background] = "#000000";
            colorsMap[(int)ColorEnum.Black] = "#2F4F4F";
            colorsMap[(int)ColorEnum.Grey] = "#696969";
            colorsMap[(int)ColorEnum.BrightGrey] = "#A9A9A9";
            colorsMap[(int)ColorEnum.Silver] = "#778899";
            colorsMap[(int)ColorEnum.Beige] = "#FFE4B5";
            colorsMap[(int)ColorEnum.BrightBeige] = "#F5F5DC";
            colorsMap[(int)ColorEnum.White] = "#D3D3D3";
            colorsMap[(int)ColorEnum.BrightWhite] = "#FFFFFF";
            colorsMap[(int)ColorEnum.Red] = "#8B0000";
            colorsMap[(int)ColorEnum.BrightRed] = "#FF0000";
            colorsMap[(int)ColorEnum.Copper] = "#D2691E";
            colorsMap[(int)ColorEnum.Orange] = "#FF4500";
            colorsMap[(int)ColorEnum.BrightOrange] = "#FFA500";
            colorsMap[(int)ColorEnum.Brown] = "#8B4513";
            colorsMap[(int)ColorEnum.BrightBrown] = "#DEB887";
            colorsMap[(int)ColorEnum.Gold] = "#FFD700";
            colorsMap[(int)ColorEnum.Yellow] = "#F0E68C";
            colorsMap[(int)ColorEnum.BrightYellow] = "#FFFF00";
            colorsMap[(int)ColorEnum.Chartreuse] = "#9ACD32";
            colorsMap[(int)ColorEnum.BrightChartreuse] = "#7FFF00";
            colorsMap[(int)ColorEnum.Green] = "#006400";
            colorsMap[(int)ColorEnum.BrightGreen] = "#32CD32";
            colorsMap[(int)ColorEnum.Turquoise] = "#00CED1";
            colorsMap[(int)ColorEnum.BrightTurquoise] = "#00FFFF";
            colorsMap[(int)ColorEnum.Blue] = "#0000CD";
            colorsMap[(int)ColorEnum.BrightBlue] = "#00BFFF";
            colorsMap[(int)ColorEnum.Diamond] = "#E0FFFF";
            colorsMap[(int)ColorEnum.Purple] = "#800080";
            colorsMap[(int)ColorEnum.BrightPurple] = "#EE82EE";
            colorsMap[(int)ColorEnum.Pink] = "#FF1493";
            colorsMap[(int)ColorEnum.BrightPink] = "#FF69B4";

            // Ensure window is visible with reasonable size
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // initialize keyboard handlers if not wired via XAML events
            this.KeyDown += (s, e) => { /* routed to OnKeyDown via XAML attribute too */ };

            // Start game when window is opened
            this.Opened += MainWindow_Opened;

            InitializeGrid();

            // initialize audio subsystem (best effort)
            Mixer.Initialise(1.0f, 1.0f);
        }

        // Play mode enum (same semantics used in the WPF app)
        enum PlayModeEnum
        {
            NewGame,
            ExistingGame,
            ReplayGame
        }

        // Start the GameServer on a background Task when the window opens.
        // This mirrors the WPF behavior that began the game loop in a background worker.
        private async void MainWindow_Opened(object? sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    GameServer gameServer = new GameServer();
                    string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string savePath = Path.Combine(myDocumentsPath, "My Games");
                    Directory.CreateDirectory(savePath);
                    string saveFilename = Path.Combine(savePath, "angbandos.savefile");
                    string replayFilename = Path.Combine(savePath, "replay.json");
                    string jsonSaveFilename = Path.Combine(savePath, "savegame.json");
                    ICorePersistentStorage persistentStorage = new FileSystemCorePersistentStorage(saveFilename);
                    PlayModeEnum playMode = File.Exists(jsonSaveFilename) ? PlayModeEnum.ExistingGame : File.Exists(replayFilename) ? PlayModeEnum.ReplayGame : PlayModeEnum.NewGame;
                    ReplayPersistentStorageDriver replayPersistentStorage = new ReplayPersistentStorageDriver(replayFilename);
                    GameConfiguration gameConfiguration = new AngbandOS.GamePacks.Cthangband.CthangbandGameConfiguration();
                    GameResults gameResults;
                    if (playMode == PlayModeEnum.ExistingGame)
                    {
                        byte[] serializedSaveGameData = File.ReadAllBytes(jsonSaveFilename);
                        gameResults = gameServer.PlayExistingGame(this, persistentStorage, replayPersistentStorage, gameConfiguration, serializedSaveGameData);
                    }
                    else if (playMode == PlayModeEnum.ReplayGame)
                    {
                        GameReplayDetails gameReplayDetails = replayPersistentStorage.GetReplay();
                        gameResults = gameServer.ReplayGame(this, persistentStorage, replayPersistentStorage, gameConfiguration, gameReplayDetails);
                    }
                    else
                    {
                        gameResults = gameServer.PlayNewGame(this, persistentStorage, replayPersistentStorage, gameConfiguration);
                    }

                    // Save the game to disk if anything was returned.
                    if (gameResults.SerializedGameData?.Length > 0)
                    {
                        File.WriteAllBytes(jsonSaveFilename, gameResults.SerializedGameData);
                    }
                }
                catch (Exception ex)
                {
                    // Propagate exception to UI thread for display
                    Dispatcher.UIThread.Post(() => GameExceptionThrown(ex.Message));
                }
            });

            // Close the window (same behavior as WPF background worker completion)
            Dispatcher.UIThread.Post(() => this.Close());
        }

        // IViewPort / IConsoleAndViewPort implementation
        public int ViewPortHeight => ViewPortHeightConst;
        public int ViewPortWidth => ViewPortWidthConst;
        int IViewPort.Height => ViewPortHeight;
        int IViewPort.Width => ViewPortWidth;

        public void Clear()
        {
            // run on UI thread
            Dispatcher.UIThread.Post(() =>
            {
                Color backColor = FromHex(colorsMap[(int)ColorEnum.Background]);
                foreach (var row in Cells)
                {
                    foreach (var cell in row)
                    {
                        cell.Text = " ";
                        cell.Background = new SolidColorBrush(backColor);
                    }
                }
            });
        }

        public void BatchPrint(PrintLine[] printLines)
        {
            Dispatcher.UIThread.Post(() =>
            {
                foreach (var pl in printLines)
                {
                    Print(pl.row, pl.col, pl.text, pl.foreColor, pl.backColor);
                }
            });
        }

        private void Print(int row, int col, string text, ColorEnum foreColor, ColorEnum backColor)
        {
            Color mappedForeColor = FromHex(colorsMap[(int)foreColor]);
            Color mappedBackColor = FromHex(colorsMap[(int)backColor]);
            foreach (char c in text)
            {
                if (row >= 0 && row < ViewPortHeight && col >= 0 && col < ViewPortWidth)
                {
                    char printable = c < 32 ? '?' : c;
                    TextBlock t = Cells[row][col];
                    t.Foreground = new SolidColorBrush(mappedForeColor);
                    t.Background = new SolidColorBrush(mappedBackColor);
                    t.Text = printable.ToString();
                }
                col++;
            }
        }

        public void SetBackground(BackgroundImageEnum image)
        {
            // Best-effort: not all platforms or deployments will include images. Ignore missing images.
            Dispatcher.UIThread.Post(() =>
            {
                _backgroundImage = image;
                // Do not throw if assets unavailable. Placeholder behavior.
                try
                {
                    // No-op in this minimal port. If you include background assets in Avalonia project,
                    // set Root.Background = new ImageBrush(new Bitmap("avares://AngbandOS.Avalonia/Assets/Backgrounds/Default.png"));
                }
                catch { }
            });
        }

        public char? GetKey()
        {
            if (!KeyQueue.TryDequeue(out char key))
            {
                return null;
            }
            return key;
        }

        // Audio
        public void PlaySound(SoundEffectEnum sound)
        {
            // Best-effort; run on UI thread to match WPF behavior where Mixer is UI-affined.
            Dispatcher.UIThread.Post(() =>
            {
                if (Mixer.SoundVolume > 0)
                {
                    Mixer.Play(sound);
                }
            });
        }

        public void PlayMusic(MusicTrackEnum musicTrack)
        {
            Dispatcher.UIThread.Post(() =>
            {
                Mixer.Play(musicTrack);
            });
        }

        private Color FromHex(string hex)
        {
            // Expects #RRGGBB or #AARRGGBB
            try
            {
                return Color.Parse(hex);
            }
            catch
            {
                return Colors.Black;
            }
        }

        // --- UI construction & input handling ---

        private void InitializeGrid()
        {
            // Create a UniformGrid-like layout in code using UniformGrid from Avalonia.Controls.Primitives.
            var root = this.FindControl<Border>("Root");
            root.Child = null;

            var uniform = new UniformGrid
            {
                Rows = ViewPortHeight,
                Columns = ViewPortWidth,
                Background = null,
                IsHitTestVisible = false,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            for (int row = 0; row < ViewPortHeight; row++)
            {
                Cells[row] = new TextBlock[ViewPortWidth];
                for (int col = 0; col < ViewPortWidth; col++)
                {
                    var viewbox = new Viewbox { Stretch = Stretch.Fill, Width = double.NaN, Height = double.NaN };
                    var tb = new TextBlock
                    {
                        Text = " ",
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = Brushes.White,
                        Background = Brushes.Transparent
                    };
                    viewbox.Child = tb;
                    uniform.Children.Add(viewbox);
                    Cells[row][col] = tb;
                }
            }

            root.Child = uniform;
        }

        // Map keyboard keys similar to WPF implementation.
        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            // Map keys to the same numeric keypad / control scheme used by the WPF app.
            // Keep event marked handled where we enqueue a mapped char.
            switch (e.Key)
            {
                case Key.Tab:
                    e.Handled = true;
                    EnqueueChar('\x09');
                    break;
                case Key.Enter:
                    e.Handled = true;
                    EnqueueChar('\x0D');
                    break;
                case Key.PageUp:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('9');
                    break;
                case Key.PageDown:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('3');
                    break;
                case Key.End:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('1');
                    break;
                case Key.Home:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('7');
                    break;
                case Key.Left:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('4');
                    break;
                case Key.Up:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('8');
                    break;
                case Key.Right:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('6');
                    break;
                case Key.Down:
                    e.Handled = true;
                    if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.');
                    EnqueueChar('2');
                    break;
                case Key.Clear:
                    e.Handled = true;
                    EnqueueChar('5');
                    break;
                default:
                    // not handled here
                    break;
            }
        }

        private void OnTextInput(object? sender, TextInputEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Text))
            {
                char ch = e.Text[0];
                if (ch < 255)
                {
                    EnqueueChar(ch);
                }
            }
        }

        private void EnqueueChar(char ch)
        {
            lock (KeyQueue)
            {
                KeyQueue.Enqueue(ch);
            }
        }

        // Boilerplate IConsoleAndViewPort methods not used in this port:
        public void MessagesUpdated() { }
        public void PlayerDied(string name, string diedFrom, int level) { }
        public void GoldUpdated(int gold) { }
        public void CharacterRenamed(string name) { }
        public void ExperienceLevelChanged(int level) { }
        public void GameStarted() { }
        public void GameStopped() { }
        public void GameExceptionThrown(string message)
        {
            // Simple fallback to Avalonia dialog: use Task to ensure on UI thread.
            Dispatcher.UIThread.Post(async () =>
            {
                var dlg = new Window
                {
                    Title = "Game Exception",
                    Width = 400,
                    Height = 200,
                    Content = new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap }
                };
                await dlg.ShowDialog(this);
            });
        }
        public void GameTimeElapsed() { }
        public void InputReceived() { }
        public void MessagesReceived(IGameMessage[] gameMessages) { }
    }

    // Minimal platform-agnostic Mixer for the Avalonia front-end.
    // This mirrors the WPF Mixer API used by the core game but keeps implementation simple.
    internal class Mixer
    {
        public float MusicVolume = 1;
        public float SoundVolume = 1;

        // Minimal constructor
        public Mixer() { }

        public void Initialise(float musicVolume, float soundVolume)
        {
            MusicVolume = musicVolume;
            SoundVolume = soundVolume;
        }

        public void Play(MusicTrackEnum musicTrack)
        {
            // No-op for cross-platform default. Add platform audio integration as needed.
        }

        public void Play(SoundEffectEnum sound)
        {
            // No-op for cross-platform default. Add platform audio integration as needed.
        }
    }
}