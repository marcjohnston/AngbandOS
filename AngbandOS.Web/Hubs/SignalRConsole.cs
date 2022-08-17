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
        private readonly string Guid;
        private readonly GameServer GameServer;
        private readonly IPersistentStorage PersistentStorage;

        public SignalRConsole(GameServer gameServer, IGameHub gameHub, string guid, IPersistentStorage persistentStorage)
        {
            Guid = guid;
            _gameHub = gameHub;
            GameServer = gameServer;
            PersistentStorage = persistentStorage;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            // This thread will initiate the play command on the game with this SignalRConsole object also acting as the injected
            // IConsole to receive and process print and wait for key requests.
            GameServer.Play(Guid, this, PersistentStorage);

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

        public void SetCellBackground(int row, int col, string color)
        {
            // Forward the set cell background command from the game to the signal-r hub.
            _gameHub.SetCellBackground(row, col, color);
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
