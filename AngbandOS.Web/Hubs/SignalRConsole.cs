using Cthangband;
using Microsoft.AspNetCore.SignalR;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Collections.Concurrent;
using AngbandOS.Interface;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a console interface to accept messages from an active game and send the message via a SignalR hub.  This class operates 
    /// as a background worker to process incoming messages and send outgoing messages without blocking the main thread.
    /// </summary>
    public class SignalRConsole : BackgroundWorker, IConsole
    {
        public readonly ConcurrentQueue<char> KeyQueue = new ConcurrentQueue<char>();
        private readonly IGameHub _gameHub;
        private readonly IPersistentStorage PersistentStorage;
        private GameServer _gameServer; // This is the actual game.
        public readonly string UserId;
        public readonly string Username;
        private readonly IUpdateNotifier _updateNotifier;

        public SignalRConsole(IGameHub gameHub, IPersistentStorage persistentStorage, string userId, string username, IUpdateNotifier updateNotifier)
        {
            _gameHub = gameHub;
            PersistentStorage = persistentStorage;
            UserId = userId;
            Username = username;
            _updateNotifier = updateNotifier;
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

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            // Create a game server to play the game.  
            _gameServer = new GameServer(); // TODO: This should be simply a game object; not a game "server".

            // This thread will initiate the play command on the game with this SignalRConsole object also acting as the injected
            // IConsole to receive and process print and wait for key requests.
            _gameServer.Play(this, PersistentStorage, _updateNotifier);

            // The game is over.  Let the client know.
            _gameHub.GameOver();
        }

        public void Clear()
        {
            // Forward the clear command from the game to the signal-r hub.
            _gameHub.Clear();
        }

        public void PlayMusic(MusicTrack music)
        {
            // Forward the play music command from the game to the signal-r hub.
            _gameHub.PlayMusic(music);
        }

        public void PlaySound(SoundEffect sound)
        {
            // Forward the play sound command from the game to the signal-r hub.
            _gameHub.PlaySound(sound);
        }

        public void Print(int row, int col, string text, string colour)
        {
            // Forward the print command from the game to the signal-r hub.
            _gameHub.Print(row, col, text, colour);
        }

        public void SetBackground(BackgroundImage image)
        {
            // Forward the set background command from the game to the signal-r hub.
            _gameHub.SetBackground(image);
        }

        public void SetCellBackground(int row, int col, char c, string color)
        {
            // Forward the set cell background command from the game to the signal-r hub.
            _gameHub.SetCellBackground(row, col, c, color);
        }

        public void UnsetCellBackground(int row, int col, char c, string color)
        {
            // Forward the set cell background command from the game to the signal-r hub.
            _gameHub.UnsetCellBackground(row, col, c, color);
        }

        /// <summary>
        /// Inserts a new keystroke into the queue for the game to use.
        /// </summary>
        /// <param name="c"></param>
        public void Keypressed(string keys)
        {
            foreach (char c in keys)
            {
                KeyQueue.Enqueue(c);
            }
        }

        public char WaitForKey()
        {
            char c;
            // Wait until there is a key from the client.
            while (!KeyQueue.TryDequeue(out c))
            {
                Thread.Sleep(5); // TODO: Use a wait event
            }

            // Return the key.
            return c;
        }
    }
}
