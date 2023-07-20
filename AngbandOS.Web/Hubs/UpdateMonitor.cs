//using AngbandOS.Core.Interface;
//using AngbandOS.Web.Interface;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Security.Claims;

//namespace AngbandOS.Web.Hubs
//{
//    /// <summary>
//    /// Represents an object that implements the IUpdateMonitor interface so that the SignalRConsole can receive interesting updates from the game.
//    /// This monitor object converts the game notifications into meaningful messages that the game service can process.
//    /// </summary>
//    public class UpdateMonitor
//    {
//        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
//        private readonly ClaimsPrincipal User;
//        private readonly string Guid;

//        public UpdateMonitor(ClaimsPrincipal user, string guid, IHubContext<ServiceHub, IServiceHub> serviceHub)
//        {
//            ServiceHub = serviceHub;
//            User = user;
//            Guid = guid;
//        }

//        public void CharacterRenamed(string name)
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            string message = $"{name} was just birthed.";
//            Action(SignalRConsole, GameUpdateNotificationEnum.CharacterRenamed, message);
//        }

//        public void GameStarted()
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.GameStarted, "Game started.");
//        }

//        public void GoldUpdated(int gold)
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.GoldUpdated, "Gold updated.");
//        }

//        public void LevelChanged(int level)
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.LevelChanged, "Level changed.");
//        }
//        public void GameStopped()
//        {
//            ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameStopped, guid);
//        }

//        public void PlayerDied(string name, string diedFrom, int level)
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            string message = $"{name.Trim()} was just killed by {diedFrom} on level {level}.";
//            await WriteMessageAsync(context.User, null, message, MessageTypeEnum.CharacterDied, guid);
//        }

//        public void GameExceptionThrown(string message)
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.GameExceptionThrown, message);
//        }

//        public void GameTimeElapsed()
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.GameTimeElapsed, "Game time elapsed.");
//        }

//        public void InputReceived()
//        {
//            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
//            Action(SignalRConsole, GameUpdateNotificationEnum.InputReceived, "Game input received.");
//        }
//    }
//}
