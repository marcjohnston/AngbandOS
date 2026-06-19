using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using AngbandOS.PersistentStorage.FileSystem;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngbandOS.Avalonia;
public partial class MainWindow : Window, IConsoleAndViewPort
{
    // Viewport
    public const int ViewPortHeightConst = 45;
    public const int ViewPortWidthConst = 80;

    public readonly Queue<char> KeyQueue = new Queue<char>();
    private RendererControl? _renderer;

    private readonly Mixer Mixer = new Mixer();

    public MainWindow()
    {
        InitializeComponent();

        // prepare UI
        this.Opened += MainWindow_Opened;

        Width = ViewPortWidthConst * cellWidth;
        Height = ViewPortHeightConst * cellHeight;

        // Add a single lightweight renderer control which overrides Render.
        _renderer = new RendererControl(ViewPortWidth, ViewPortHeight);
        this.Content = _renderer;

        Mixer.Initialize(1.0f, 1.0f);
        this.Focus(); // ensure key events
    }
    private int cellHeight = 18;
    private int cellWidth = 10;

    // Start game when opened (same logic as before)
    enum PlayModeEnum { NewGame, ExistingGame, ReplayGame }
    private void RunGame()
    {
        GameServer gameServer = new GameServer();
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string savePath = Path.Combine(myDocumentsPath, "AngbandOS");
        Directory.CreateDirectory(savePath);
        string replayFilename = Path.Combine(savePath, "AngbandOS.replay");
        string saveFilename = Path.Combine(savePath, "AngbandOS.save");
        PlayModeEnum playMode = File.Exists(saveFilename) ? PlayModeEnum.ExistingGame : File.Exists(replayFilename) ? PlayModeEnum.ReplayGame : PlayModeEnum.NewGame;
        ReplayPersistentStorageDriver replayPersistentStorage = new ReplayPersistentStorageDriver(replayFilename);
        GameConfiguration gameConfiguration = new CthangbandGameConfiguration();
        GameResults gameResults;
        if (playMode == PlayModeEnum.ExistingGame)
        {
            byte[] serializedSaveGameData = File.ReadAllBytes(saveFilename);
            gameResults = gameServer.PlayExistingGame(this, replayPersistentStorage, gameConfiguration, serializedSaveGameData);
        }
        else if (playMode == PlayModeEnum.ReplayGame)
        {
            GameReplayDetails gameReplayDetails = replayPersistentStorage.GetReplay();
            gameResults = gameServer.ReplayGame(this, replayPersistentStorage, gameConfiguration, gameReplayDetails);
        }
        else
        {
            gameResults = gameServer.PlayNewGame(this, replayPersistentStorage, gameConfiguration);
        }

        if (gameResults.SerializedGameData?.Length > 0)
        {
            File.WriteAllBytes(saveFilename, gameResults.SerializedGameData);
        }
    }

    private async void MainWindow_Opened(object? sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            try
            {
                RunGame();
            }
            catch (Exception ex)
            {
                Dispatcher.UIThread.Post(() => GameExceptionThrown(ex.Message));
            }
        });

        Dispatcher.UIThread.Post(() => this.Close());
    }

    // IViewPort / IConsoleAndViewPort
    public int ViewPortHeight => ViewPortHeightConst;
    public int ViewPortWidth => ViewPortWidthConst;
    int IViewPort.Height => ViewPortHeight;
    int IViewPort.Width => ViewPortWidth;

    public void Clear()
    {
        _renderer?.Clear();
    }

    public void BatchPrint(PrintLine[] printLines)
    {
        _renderer?.Update(printLines);
    }

    public char? GetKey()
    {
        if (!KeyQueue.TryDequeue(out var k)) return null;
        return k;
    }

    // audio stubs
    public void PlaySound(SoundEffectEnum sound) { Dispatcher.UIThread.Post(() => { if (Mixer.SoundVolume > 0) Mixer.Play(sound); }); }
    public void PlayMusic(MusicTrackEnum music) { Dispatcher.UIThread.Post(() => Mixer.Play(music)); }

    // input
    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Tab: e.Handled = true; EnqueueChar('\x09'); break;
            case Key.Enter: e.Handled = true; EnqueueChar('\x0D'); break;
            case Key.PageUp: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('9'); break;
            case Key.PageDown: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('3'); break;
            case Key.End: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('1'); break;
            case Key.Home: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('7'); break;
            case Key.Left: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('4'); break;
            case Key.Up: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('8'); break;
            case Key.Right: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('6'); break;
            case Key.Down: e.Handled = true; if ((e.KeyModifiers & KeyModifiers.Shift) != 0) EnqueueChar('.'); EnqueueChar('2'); break;
            case Key.Clear: e.Handled = true; EnqueueChar('5'); break;
            case Key.Escape: e.Handled = true; EnqueueChar('\x1b'); break;
            case Key.Back: e.Handled = true; EnqueueChar('\x08'); break;
        }
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text) && e.Text[0] < 255) EnqueueChar(e.Text[0]);
    }

    private void EnqueueChar(char ch) { lock (KeyQueue) KeyQueue.Enqueue(ch); }

    public void MessagesUpdated() { }
    public void PlayerDied(string name, string diedFrom, int level) { }
    public void GoldUpdated(int gold) { }
    public void CharacterRenamed(string name) { }
    public void ExperienceLevelChanged(int level) { }
    public void GameStarted() { }
    public void GameStopped() { }
    public void GameExceptionThrown(string message)
    {
        Dispatcher.UIThread.Post(async () =>
        {
            var dlg = new Window { Title = "Game Exception", Width = 400, Height = 200, Content = new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap } };
            await dlg.ShowDialog(this);
        });
    }
    public void GameTimeElapsed() { }
    public void InputReceived() { }
    public void MessagesReceived(IGameMessage[] gameMessages) { }

    public void SetBackground(BackgroundImageEnum image)
    {
    }
}