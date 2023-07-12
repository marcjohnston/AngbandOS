using AngbandOS.Core;
using AngbandOS.Core.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a console interface to accept messages from an active game and send the message via a SignalR hub.  This class operates 
    /// as a background worker to process incoming messages and send outgoing messages without blocking the main thread.
    /// </summary>
    public class SignalRConsole : BackgroundWorker, IConsole
    {
        public readonly ConcurrentQueue<char> KeyQueue = new ConcurrentQueue<char>(); // This is the queue of keystrokes provided by the player.
        private readonly IGameHub _consoleGameHub; // This is the signal-r hub that the console is communicating on.
        private readonly List<ISpectatorsHub> _spectators = new List<ISpectatorsHub>(); // This is the list of people watching the game.
        private readonly ICorePersistentStorage PersistentStorage; // This is the game persistence.
        private GameServer _gameServer; // This is the actual game.
        public readonly string UserId; // This is the ID of the player.
        public readonly string Username; // This is the username of the player.
        private readonly Action<SignalRConsole, GameUpdateNotificationEnum, string> NotificationAction; // This is the notification channel.
        private readonly HubCallerContext Context; // Used to abort the signal-r connection and terminate the game instantly.
        private bool ShuttingDown = false;

        public SignalRConsole(HubCallerContext context, IGameHub gameHub, ICorePersistentStorage persistentStorage, string userId, string username, Action<SignalRConsole, GameUpdateNotificationEnum, string> notificationAction)
        {
            _consoleGameHub = gameHub;
            PersistentStorage = persistentStorage;
            UserId = userId;
            Username = username;
            NotificationAction = notificationAction;
            Context = context;
        }

        public void Shutdown()
        {
            // Set the game flag to shut down.  Do this first, because we need to game to exit quickly when keypresses are bypassed.
            if (_gameServer != null)
                _gameServer.InitiateShutDown();

            // Set the flag to force the input queue to shut down.  This will bypass the keystrokes.
            ShuttingDown = true;

        }

        public void Kill()
        {
            Shutdown();
        }

        public void AddWatcher(ISpectatorsHub watcherHub)
        {
            _spectators.Add(watcherHub);

            // Send a request to the game to refresh the screen.
            _gameServer.RefreshSpectatorConsole(new SpectatorConsole(watcherHub));
        }

        public void RemoveWatcher(ISpectatorsHub watcherHub)
        {
            _spectators.Remove(watcherHub);
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
            if (_gameServer.Play(this, PersistentStorage, new UpdateMonitor(this, NotificationAction)))
            {
                // The game is over.  Let the client know.
                GameOver();
            }
            DisconnectSpectators();

            // Abort the context.  This will throw the signal-r disconnect?
            Context.Abort();
        }

        private void DisconnectSpectators()
        {
            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub gameHub in _spectators)
                gameHub.GameOver();
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
        /// Sends a generic message to the console.
        /// </summary>
        /// <param name="message"></param>
        public void SendConsoleMessage(string message)
        {
            _consoleGameHub.SendMessage(message);
        }

        /// <summary>
        /// Sends a message to the console that the game cannot be played because it is incompatible.
        /// </summary>
        /// <param name="message"></param>
        public void GameIncompatible()
        {
            _consoleGameHub.GameIncompatible();
        }

        public void Clear()
        {
            // Forward the clear command from the game to the signal-r hub.
            _consoleGameHub.Clear();

            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub gameHub in _spectators)
                gameHub.Clear();
        }

        public void PlayMusic(MusicTrack music)
        {
            // Forward the play music command from the game to the signal-r hub.
            _consoleGameHub.PlayMusic(music);

            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub gameHub in _spectators)
                gameHub.PlayMusic(music);
        }

        public void PlaySound(SoundEffect sound)
        {
            // Forward the play sound command from the game to the signal-r hub.
            _consoleGameHub.PlaySound(sound);

            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub gameHub in _spectators)
                gameHub.PlaySound(sound);
        }

        public void BatchPrint(PrintLine[] printLines)
        {
            // Forward the print command from the game to the signal-r hub.
            _consoleGameHub.BatchPrint(printLines);

            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub spectatorHub in _spectators)
                spectatorHub.BatchPrint(printLines);
        }

        public void SetBackground(BackgroundImage image)
        {
            // Forward the set background command from the game to the signal-r hub.
            _consoleGameHub.SetBackground(image);

            // These messages are relayed to all spectators.
            foreach (ISpectatorsHub gameHub in _spectators)
                gameHub.SetBackground(image);
        }

        /// <summary>
        /// Inserts a new keystroke into the queue for the game to use.
        /// </summary>
        /// <param name="c"></param>
        public void Keypressed(string keys)
        {
            if (keys != null)
            {
                foreach (char c in keys)
                {
                    KeyQueue.Enqueue(c);
                }
            }
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
    }
}
