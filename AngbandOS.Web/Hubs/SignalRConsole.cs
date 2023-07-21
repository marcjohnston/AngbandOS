using AngbandOS.Core;
using AngbandOS.Core.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an object that accept messages from an active game (AngbandOS.Core) and send the message to the client browser via a SignalR hub.  This class operates 
    /// as a background worker to process incoming messages and send outgoing messages without blocking the main thread.
    /// </summary>
    public class SignalRConsole : BackgroundWorker, IConsoleViewPort
    {
        #region State Date
        /// <summary>
        /// Returns the queue of keystrokes that is being used to store the keystrokes provided by the player.
        /// </summary>
        public readonly ConcurrentQueue<char> KeyQueue = new ConcurrentQueue<char>();

        /// <summary>
        /// Returns the signal-r hub that the console is communicating on.        
        /// </summary>
        private readonly IGameHub _consoleGameHub;

        /// <summary>
        /// Returns the list of people watching the game.
        /// </summary>
        private readonly List<ISpectatingHub> _spectators = new List<ISpectatingHub>();

        /// <summary>
        /// Returns the list of windows that are monitoring the game messages.
        /// </summary>
        private readonly List<IGameMessagesHub> _gameMessagesMonitors = new List<IGameMessagesHub>();

        /// <summary>
        /// Returns the object responsible for the persistence of the game.
        /// </summary>
        private readonly ICorePersistentStorage PersistentStorage;

        /// <summary>
        /// Returns the actual game.  The game is null, until the thread is started.
        /// </summary>
        private GameServer? _gameServer = null;

        /// <summary>
        /// Return the ID of the player.
        /// </summary>
        public readonly string UserId;

        /// <summary>
        /// Returns the username of the player.
        /// </summary>
        public readonly string Username;

        /// <summary>
        /// Returns object that handles the notification channel.
        /// </summary>
        private readonly Action<SignalRConsole, GameUpdateNotificationEnum, string> NotificationAction;

        /// <summary>
        /// Returns the context for the GameHub.  This is used to abort the signal-r connection and terminate the game instantly.
        /// </summary>
        private readonly HubCallerContext Context;

        /// <summary>
        /// Returns true, when a request to shut the game down has been received.
        /// </summary>
        private bool ShuttingDown = false;
        #endregion

        #region Constructor
        public SignalRConsole(HubCallerContext context, IGameHub gameHub, ICorePersistentStorage persistentStorage, string userId, string username, Action<SignalRConsole, GameUpdateNotificationEnum, string> notificationAction)
        {
            _consoleGameHub = gameHub;
            PersistentStorage = persistentStorage;
            UserId = userId;
            Username = username;
            NotificationAction = notificationAction;
            Context = context;
        }
        #endregion

        #region IConsole Implementation
        /// <summary>
        /// Accepts a Clear command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        public void Clear()
        {
            // Forward the clear command from the game to the signal-r hub.
            _consoleGameHub.Clear();

            // These messages are relayed to all spectators.
            foreach (ISpectatingHub gameHub in _spectators)
            {
                gameHub.Clear();
            }
        }

        /// <summary>
        /// Accepts a PlayMusic command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        /// <param name="music"></param>
        public void PlayMusic(MusicTrackEnum music)
        {
            // Forward the play music command from the game to the signal-r hub.
            _consoleGameHub.PlayMusic(music);

            // These messages are relayed to all spectators.
            foreach (ISpectatingHub gameHub in _spectators)
            {
                gameHub.PlayMusic(music);
            }
        }

        /// <summary>
        /// Accepts a PlaySound command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySound(SoundEffectEnum sound)
        {
            // Forward the play sound command from the game to the signal-r hub.
            _consoleGameHub.PlaySound(sound);

            // These messages are relayed to all spectators.
            foreach (ISpectatingHub gameHub in _spectators)
            {
                gameHub.PlaySound(sound);
            }
        }

        /// <summary>
        /// Accepts a BatchPrint command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        /// <param name="printLines"></param>
        public void BatchPrint(PrintLine[] printLines)
        {
            // Forward the print command from the game to the signal-r hub.
            _consoleGameHub.BatchPrint(printLines);

            // These messages are relayed to all spectators.
            foreach (ISpectatingHub spectatorHub in _spectators)
            {
                spectatorHub.BatchPrint(printLines);
            }
        }

        /// <summary>
        /// Accepts a SetBackground command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        /// <param name="image"></param>
        public void SetBackground(BackgroundImageEnum image)
        {
            // Forward the set background command from the game to the signal-r hub.
            _consoleGameHub.SetBackground(image);

            // These messages are relayed to all spectators.
            foreach (ISpectatingHub gameHub in _spectators)
            {
                gameHub.SetBackground(image);
            }
        }

        public bool KeyQueueIsEmpty()
        {
            return KeyQueue.IsEmpty;
        }

        /// <summary>
        /// This message is received from the game when a key is needed.
        /// </summary>
        /// <returns></returns>
        public char WaitForKey()
        {
            char c;

            // Wait until there is a key from the client.
            while (!KeyQueue.TryDequeue(out c) && !ShuttingDown)
            {
                Thread.Sleep(5); // TODO: Use a wait event
            }
            // Return the key.
            return c;
        }

        public void MessagesUpdated()
        {
            foreach (IGameMessagesHub gameMessageHub in _gameMessagesMonitors)
            {
                gameMessageHub.GameMessagesUpdated();
            }
        }

        /// <summary>
        /// Processes the PlayerDied message from the in progress game.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="diedFrom"></param>
        /// <param name="level"></param>
        public void PlayerDied(string name, string diedFrom, int level)
        {
            string message = $"{name.Trim()} was just killed by {diedFrom} on level {level}.";
            NotificationAction(this, GameUpdateNotificationEnum.PlayerDied, message);
        }

        public void CharacterRenamed(string name)
        {
            string message = $"{name} was just birthed.";
            NotificationAction(this, GameUpdateNotificationEnum.CharacterRenamed, message);
        }

        public void GameStarted()
        {
            NotificationAction(this, GameUpdateNotificationEnum.GameStarted, "Game started.");
        }

        public void GoldUpdated(int gold)
        {
            NotificationAction(this, GameUpdateNotificationEnum.GoldUpdated, "Gold updated.");
        }

        public void LevelChanged(int level)
        {
            NotificationAction(this, GameUpdateNotificationEnum.LevelChanged, "Level changed.");
        }
        public void GameStopped()
        {
            NotificationAction(this, GameUpdateNotificationEnum.GameStopped, "Game stopped.");
        }

        public void GameExceptionThrown(string message)
        {
            NotificationAction(this, GameUpdateNotificationEnum.GameExceptionThrown, message);
        }

        public void GameTimeElapsed()
        {
            NotificationAction(this, GameUpdateNotificationEnum.GameTimeElapsed, "Game time elapsed.");
        }

        public void InputReceived()
        {
            NotificationAction(this, GameUpdateNotificationEnum.InputReceived, "Game input received.");
        }
        #endregion

        #region Game Play
        public void Shutdown()
        {
            // Set the game flag to shut down.  Do this first, because we need to game to exit quickly when keypresses are bypassed.
            if (_gameServer != null)
            {
                _gameServer.InitiateShutDown();
            }

            // Set the flag to force the input queue to shut down.  This will bypass the keystrokes.
            ShuttingDown = true;

        }

        public void Kill() // TODO: Alias for Shutdown
        {
            Shutdown();
        }

        /// <summary>
        /// Returns the current level of the character in the game.  Returns null, if the game has been created yet or the player is dead.
        /// </summary>
        public int? Level
        {
            get
            {
                return _gameServer?.Level;
            }
        }

        public int? Gold
        {
            get
            {
                return _gameServer?.Gold;
            }
        }
        public string? CharacterName
        {
            get
            {
                return _gameServer?.CharacterName;
            }
        }

        public DateTime? LastInputReceived
        {
            get
            {
                return _gameServer?.LastInputReceived;
            }
        }

        public TimeSpan? ElapsedGameTime
        {
            get
            {
                return _gameServer?.ElapsedGameTime;
            }
        }

        public string? ThreadName { get; set; } = null;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Thread.CurrentThread.Name = ThreadName;

            // Create a game server to play the game.  
            _gameServer = new GameServer();

            // This thread will initiate the play command on the game with this SignalRConsole object also acting as the injected
            // IConsole to receive and process print and wait for key requests.
            if (PersistentStorage.GameExists())
            {
                if (_gameServer.PlayExistingGame(this, PersistentStorage))
                {
                    // The game is over.  Let the client know.
                    GameOver();
                }
            }
            else
            {
                if (_gameServer.PlayNewGame(this, PersistentStorage))
                {
                    // The game is over.  Let the client know.
                    GameOver();
                }
            }

            // We need to send the game-over message to all clients monitoring the game.
            DisconnectSpectators();
            DisconnectGameMessagesMonitors();

            // Abort the context.  This will throw the signal-r disconnect?
            Context.Abort();
        }

        /// <summary>
        /// Sends a message from the game to the console client and all spectators that the game is over.
        /// </summary>
        private void GameOver()
        {
            _consoleGameHub.GameOver();
            DisconnectSpectators();
        }

        /// <summary>
        /// Sends a message to the console that the game cannot be played because it is incompatible.
        /// </summary>
        /// <param name="message"></param>
        public void GameIncompatible()
        {
            _consoleGameHub.GameIncompatible();
        }

        /// <summary>
        /// Processes an incoming keystroke from the web client and inserts it into the queue for the game to use.
        /// </summary>
        /// <param name="c"></param>
        public void KeyPressed(string keys)
        {
            if (keys != null)
            {
                foreach (char c in keys)
                {
                    KeyQueue.Enqueue(c);
                }
            }
        }
        #endregion

        #region Spectating
        /// <summary>
        /// Adds a spectating window to the list of windows spectating the game.
        /// </summary>
        /// <param name="spectatorHub">The watcher hub.</param>
        public void AddSpectator(ISpectatingHub spectatorHub)
        {
            _spectators.Add(spectatorHub);

            // Send a request to the game to refresh the screen.
            _gameServer.RefreshSpectatorConsole(new SpectatingConsole(spectatorHub));
        }

        /// <summary>
        /// Removes a spectating window from the list of windows spectating the game.
        /// </summary>
        /// <param name="spectatorHub">The watcher hub.</param>
        public void RemoveSpectator(ISpectatingHub spectatorHub)
        {
            _spectators.Remove(spectatorHub);
        }

        /// <summary>
        /// Send the game over message to all of the spectating windows, so that they disconnect.  We don't actually try to force a signal-r disconnect or window close.  It
        /// is the responsibility of the receiving window to process the game over message.
        /// </summary>
        private void DisconnectSpectators()
        {
            // These messages are relayed to all spectators.
            foreach (ISpectatingHub spectatorHub in _spectators)
            {
                spectatorHub.GameOver();
            }
        }
        #endregion

        #region Game Messages Monitoring
        /// <summary>
        /// Accepts a request from a web-client to monitor the game messages.
        /// </summary>
        /// <param name="gameMessagesHub">The signal-r hub for the monitor.</param>
        /// <param name="maximumMessagesToRetrieve">The maximum messages to retrieve.</param>
        public void MonitorGameMessages(IGameMessagesHub gameMessagesHub, int? maximumMessagesToRetrieve = null)
        {
            // Add the monitor to the collection of monitors.
            if (!_gameMessagesMonitors.Contains(gameMessagesHub))
            {
                _gameMessagesMonitors.Add(gameMessagesHub);
            }

            // Send a request to the game to get the initial page of game messages.
            PageOfGameMessages? pageOfGameMessages = _gameServer.GetPageOfGameMessages(null, 0, maximumMessagesToRetrieve);

            // If there are messages, send them to the hub for the monitor.
            if (pageOfGameMessages != null)
            {
                gameMessagesHub.GameMessagesReceived(pageOfGameMessages);
            }
        }

        /// <summary>
        /// Removes a monitor from the list of clients that are monitoring the game messages.
        /// </summary>
        /// <param name="watcherHub">The watcher hub.</param>
        public void RemoveGameMessagesMonitor(IGameMessagesHub gameMessagesWindow)
        {
            _gameMessagesMonitors.Remove(gameMessagesWindow);
        }

        /// <summary>
        /// Send the game over message to all of the spectating windows, so that they disconnect.  We don't actually try to force a signal-r disconnect or window close.  It
        /// is the responsibility of the receiving window to process the game over message.
        /// </summary>
        private void DisconnectGameMessagesMonitors()
        {
            // These messages are relayed to all spectators.
            foreach (IGameMessagesHub monitorHub in _gameMessagesMonitors)
            {
                monitorHub.GameOver();
            }
        }

        public PageOfGameMessages? GetGameMessages(int? firstIndex = null, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
        {
            return _gameServer.GetPageOfGameMessages(firstIndex, lastIndex, maximumMessagesToRetrieve);
        }
        #endregion
    }
}
