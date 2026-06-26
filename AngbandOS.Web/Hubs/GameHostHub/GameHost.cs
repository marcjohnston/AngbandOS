using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Web.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace AngbandOS.Web.Hubs
{

    /// <summary>
    /// Represents an object that accept messages from an active game (AngbandOS.Core) and send the message to the client browser via a SignalR hub.  This class operates 
    /// as a background worker to process incoming messages and send outgoing messages without blocking the main thread.
    /// </summary>
    public class GameHost : BackgroundWorker, IConsoleAndViewPort
    {
        #region State Date
        /// <summary>
        /// Returns the queue of keystrokes that is being used to store the keystrokes provided by the player.
        /// </summary>
        public readonly ConcurrentQueue<char> KeyQueue = new ConcurrentQueue<char>();

        /// <summary>
        /// Returns the signal-r hub that the console is communicating on.        
        /// </summary>
        private readonly IConsoleHubMessages _consoleGameHub;

        /// <summary>
        /// Returns the list of people watching the game.
        /// </summary>
        private readonly List<ISpectatorHubMessages> _spectators = new List<ISpectatorHubMessages>();

        /// <summary>
        /// Returns the list of windows that are monitoring the game messages.
        /// </summary>
        private readonly List<IGameMessagesHubMessages> _gameMessagesMonitors = new List<IGameMessagesHubMessages>();

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
        /// Returns object that handles the notification channel.  Will be null for replay mode.
        /// </summary>
        private readonly Action<GameHost, GameUpdateNotificationEnum, string>? NotificationAction = null;

        /// <summary>
        /// Returns the context for the GameHub.  This is used to abort the signal-r connection and terminate the game instantly.
        /// </summary>
        private readonly HubCallerContext Context;

        /// <summary>
        /// Returns true, when a request to shut the game down has been received.
        /// </summary>
        private bool ShuttingDown = false;

        private readonly RunContext RunContext;
        private readonly IWebPersistentStorage WebPersistentStorage;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs a <see cref="GameHost"/> object to play a new game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="gameHub"></param>
        /// <param name="persistentStorage"></param>
        /// <param name="userId">The user ID of the player.  This property is used to GET ActiveGames controller to return the user ID of the player.</param>
        /// <param name="username">The username for the player.  This property is used by the GET ActiveGames controller to return the name of the player./></param>
        /// <param name="notificationAction"></param>
        public GameHost(HubCallerContext context, IConsoleHubMessages gameHub, GameConfiguration gameConfiguration, string userId, string username, Action<GameHost, GameUpdateNotificationEnum, string>? notificationAction, IWebPersistentStorage webPersistentStorage)
        {
            _consoleGameHub = gameHub;
            UserId = userId;
            Username = username;
            NotificationAction = notificationAction;
            Context = context;
            WebPersistentStorage = webPersistentStorage;
            RunContext = new PlayNewGameRunContext(userId, gameConfiguration, webPersistentStorage);
        }

        /// <summary>
        /// Constructs a <see cref="GameHost"/> object to play an existing game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="gameHub"></param>
        /// <param name="persistentStorage"></param>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        /// <param name="notificationAction"></param>
        public GameHost(HubCallerContext context, IConsoleHubMessages gameHub, GameConfiguration gameConfiguration, string userId, string username, Action<GameHost, GameUpdateNotificationEnum, string>? notificationAction, IWebPersistentStorage webPersistentStorage, string gameGuid)
        {
            _consoleGameHub = gameHub;
            UserId = userId;
            Username = username;
            NotificationAction = notificationAction;
            Context = context;
            WebPersistentStorage = webPersistentStorage;
            RunContext = new PlayExistingGameRunContext(userId, gameConfiguration, webPersistentStorage, gameGuid);
        }

        /// <summary>
        /// Constructs a <see cref="GameHost"/> object to replay a game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="gameHub"></param>
        /// <param name="persistentStorage"></param>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        /// <param name="notificationAction"></param>
        public GameHost(HubCallerContext context, IConsoleHubMessages gameHub, GameConfiguration gameConfiguration, string userId, string username, IWebPersistentStorage webPersistentStorage, int replayId, bool saveAfterReplay)
        {
            _consoleGameHub = gameHub;
            UserId = userId;
            Username = username;
            Context = context;
            WebPersistentStorage = webPersistentStorage;
            RunContext = new ReplayGameRunContext(userId, gameConfiguration, webPersistentStorage, replayId, saveAfterReplay);
        }
        #endregion

        #region IConsole Implementation for Messages from the Game to the Web Client
        public int Height => 45;
        public int Width => 80;

        /// <summary>
        /// Accepts a Clear command sent by the AngbandOS core game and forwards the event to the console and all spectators.
        /// </summary>
        public void Clear()
        {
            // Forward the clear command from the game to the signal-r hub.
            _consoleGameHub.Clear();

            // These messages are relayed to all spectators.
            foreach (ISpectatorHubMessages gameHub in _spectators)
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
            foreach (ISpectatorHubMessages gameHub in _spectators)
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
            foreach (ISpectatorHubMessages gameHub in _spectators)
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
            foreach (ISpectatorHubMessages spectatorHub in _spectators)
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
            foreach (ISpectatorHubMessages gameHub in _spectators)
            {
                gameHub.SetBackground(image);
            }
        }

        /// <summary>
        /// This message is received from the game when a key is needed.
        /// </summary>
        /// <returns></returns>
        public char? GetKey()
        {
            if (!KeyQueue.TryDequeue(out char c))
            {
                return null;
            }
            return c;
        }

        public void MessagesUpdated()
        {
            foreach (IGameMessagesHubMessages gameMessageHub in _gameMessagesMonitors)
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
            if (NotificationAction is not null)
            {
                string message = $"{name.Trim()} was just killed by {diedFrom} on level {level}.";
                NotificationAction(this, GameUpdateNotificationEnum.PlayerDied, message);
            }
        }

        public void CharacterRenamed(string name)
        {
            if (NotificationAction is not null)
            {
                string message = $"{name} was just birthed.";
                NotificationAction(this, GameUpdateNotificationEnum.CharacterRenamed, message);
            }
        }

        public void GameStarted()
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.GameStarted, "Game started.");
            }
        }

        public void GoldUpdated(int gold)
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.GoldUpdated, "Gold updated.");
            }
        }

        public void ExperienceLevelChanged(int level)
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.ExperienceLevelChanged, "Experience level changed.");
            }
        }
        public void GameStopped()
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.GameStopped, "Game stopped.");
            }
        }

        public void GameExceptionThrown(string message)
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.GameExceptionThrown, message);
            }
        }

        public void GameTimeElapsed()
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.GameTimeElapsed, "Game time elapsed.");
            }
        }

        public void InputReceived()
        {
            if (NotificationAction is not null)
            {
                NotificationAction(this, GameUpdateNotificationEnum.InputReceived, "Game input received.");
            }
        }
        #endregion

        #region Incoming Messages from the Web Client and the Game Service
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
                    KeyQueue.Enqueue(c); // TODO: Use a wait event
                }
            }
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
        /// Kill the game whether it is in-progress or not.
        /// </summary>
        public void Kill() // TODO: Alias for Shutdown
        {
            // Check to see if the game is in progress.
            if (_gameServer is not null)
            {
                // Set the game flag to shut down.Do this first, because we need to game to exit quickly when keypresses are bypassed.
                _gameServer.InitiateShutDown();
            }

            // Set the flag to force the input queue to shut down.  This will bypass the keystrokes.
            ShuttingDown = true;

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

        /// <summary>
        /// Returns the amount of time that has elapsed for the character in game time.  This is not real-world playing time.
        /// </summary>
        public TimeSpan? ElapsedGameTime
        {
            get
            {
                return _gameServer?.ElapsedGameTime;
            }
        }

        public string? ThreadName { get; set; } = null;

        /// <summary>
        /// Sends a refresh update of the game to the specified viewport--which can be the game console or a spectator.
        /// </summary>
        /// <param name="viewPort"></param>
        public void RefreshViewPort(IViewPort viewPort)
        {
            // Check to see if the game is in-progress.
            if (_gameServer is not null)
            {
                _gameServer.RefreshViewPort(viewPort);
            }
        }
        #endregion

        #region Game Play Thread Loop
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            try
            {
                Thread.CurrentThread.Name = ThreadName;

                // Create the game server object.
                _gameServer = new GameServer();

                // Play the game.
                GameResults results = RunContext.Play(this, _gameServer);

                // Null the game server quickly so that the disconnect from the hub doesn't trigger a kill on the game.
                _gameServer = null;

                // Render game over message.
                if (results.GameIsOver)
                {
                    // The game is over.  Let the client know.  Also, sends a message from the game to the console client and all spectators that the game is over.
                    _consoleGameHub.GameOver();
                }

                // We need to send the game-over message to all clients monitoring the game.
                DisconnectSpectators();

                // Update the monitoring too.
                DisconnectGameMessagesMonitors();

                // Abort the context.  This will throw the signal-r disconnect?
                Context.Abort();
            }
            catch (ReplayVerificationFailureException replayVerificationException)
            {
                _consoleGameHub.GameOver($"Replay verification failed!");
            }
            catch (Exception ex)
            {
                _consoleGameHub.GameOver($"Game error!  {ex.Message}");
            }
        }
        #endregion

        #region Spectators Management
        /// <summary>
        /// Returns a spectator viewport after adding a new spectator to the game.
        /// </summary>
        /// <param name="spectatorHub">The watcher hub.</param>
        public IViewPort AddSpectator(ISpectatorHubMessages spectatorHub)
        {
            _spectators.Add(spectatorHub);

            IViewPort viewPort = new SpectatorViewPort(spectatorHub);

            // Send a request to the game to refresh the screen.           
            _gameServer.RefreshViewPort(viewPort);

            return viewPort;
        }

        /// <summary>
        /// Removes a spectating window from the list of windows spectating the game.
        /// </summary>
        /// <param name="spectatorHub">The watcher hub.</param>
        public void RemoveSpectator(ISpectatorHubMessages spectatorHub)
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
            foreach (ISpectatorHubMessages spectatorHub in _spectators)
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
        public void MonitorGameMessages(IGameMessagesHubMessages gameMessagesHub, int? maximumMessagesToRetrieve = null)
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
        public void RemoveGameMessagesMonitor(IGameMessagesHubMessages gameMessagesWindow)
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
            foreach (IGameMessagesHubMessages monitorHub in _gameMessagesMonitors)
            {
                monitorHub.GameOver();
            }
        }

        public PageOfGameMessages? GetGameMessages(int? firstIndex = null, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
        {
            return _gameServer.GetPageOfGameMessages(firstIndex, lastIndex, maximumMessagesToRetrieve);
        }

        /// <summary>
        /// Receives an event from the active game that messages from the previous command have been received.
        /// </summary>
        /// <param name="gameMessages"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void MessagesReceived(IGameMessage[] gameMessages)
        {
            // TODO: We need to implement this for the client.
        }
        #endregion
    }
}
