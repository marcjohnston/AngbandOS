using Cthangband;
using Microsoft.AspNetCore.SignalR;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Collections.Concurrent;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a console interface to accept messages from an active game and send the message via a SignalR hub.
    /// </summary>
    public class SignalRConsole : BackgroundWorker, IConsole
    {
        public readonly ConcurrentQueue<char> KeyQueue = new ConcurrentQueue<char>();
        private readonly IHubContext<GameHub, IGameHub> GameContext;
        private readonly string ConnectionId;
        private readonly string Guid;
        private readonly GameServer2 GameServer;

        public SignalRConsole(GameServer2 gameServer, IHubContext<GameHub, IGameHub> gameContext, string connectionId, string guid)
        {
            Guid = guid;
            GameContext = gameContext;
            ConnectionId = connectionId;
            GameServer = gameServer;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            GameServer.Play(Guid, this);
        }

        public void Clear()
        {
            // Forward the clear command from the game to the signal-r hub.
            GameContext.Clients.All.Clear();
          //  GameHub.Clear();
        }

        public void PlayMusic(MusicTrack music)
        {
            // Forward the play music command from the game to the signal-r hub.
        //    GameHub.PlayMusic(music);
        }

        public void PlaySound(SoundEffect sound)
        {
            // Forward the play sound command from the game to the signal-r hub.
        //    GameHub.PlaySound(sound);
        }

        public void Print(int row, int col, string text, string colour)
        {
            // Forward the print command from the game to the signal-r hub.
            //GameContext.Clients.User(ConnectionId).Print(row, col, text, colour);
            GameContext.Clients.All.Print(row, col, text, colour);
//            GameHub.Print(row, col, text, colour);  
        }

        public void SetBackground(BackgroundImage image)
        {
            // Forward the set background command from the game to the signal-r hub.
     //       GameHub.SetBackground(image);
        }

        public void SetCellBackground(int row, int col, string color)
        {
            // Forward the set cell background command from the game to the signal-r hub.
   //         GameHub.SetCellBackground(row, col, color);
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
                Thread.Sleep(5);
            }

            // Return the key.
            return c;
        }
    }
}
