using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.MySql.Entities;
using AngbandOS.Web.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class MySqlWebPersistentStorage : IWebPersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        public MySqlWebPersistentStorage(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
        }

        public async Task<UserSettingsDetails?> GetPreferences(string userId)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Usersetting? userSetting = await context.Usersettings.SingleOrDefaultAsync(_userSetting => _userSetting.UserId == userId);
                if (userSetting == null)
                    return null;
                return new UserSettingsDetails
                {
                    FontName = userSetting.FontName,
                    FontSize = userSetting.FontSize,
                    F1Macro = userSetting.F1macro,
                    F2Macro = userSetting.F2macro,
                    F3Macro = userSetting.F3macro,
                    F4Macro = userSetting.F4macro,
                    F5Macro = userSetting.F5macro,
                    F6Macro = userSetting.F6macro,
                    F7Macro = userSetting.F7macro,
                    F8Macro = userSetting.F8macro,
                    F9Macro = userSetting.F9macro,
                    F10Macro = userSetting.F10macro,
                    F11Macro = userSetting.F11macro,
                    F12Macro = userSetting.F12macro
                };
            }
        }

        public async Task<UserSettingsDetails> WritePreferencesAsync(string userId, UserSettingsDetails userSettingsDetails)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Usersetting? userSetting = await context.Usersettings.SingleOrDefaultAsync(_userSetting => _userSetting.UserId == userId);
                if (userSetting == null)
                {
                    userSetting = new Usersetting();
                    userSetting.UserId = userId;
                    context.Usersettings.Add(userSetting);
                }
                userSetting.FontName = userSettingsDetails.FontName;
                userSetting.FontSize = userSettingsDetails.FontSize;
                userSetting.F1macro = userSettingsDetails.F1Macro;
                userSetting.F2macro = userSettingsDetails.F2Macro;
                userSetting.F3macro = userSettingsDetails.F3Macro;
                userSetting.F4macro = userSettingsDetails.F4Macro;
                userSetting.F5macro = userSettingsDetails.F5Macro;
                userSetting.F6macro = userSettingsDetails.F6Macro;
                userSetting.F7macro = userSettingsDetails.F7Macro;
                userSetting.F8macro = userSettingsDetails.F8Macro;
                userSetting.F9macro = userSettingsDetails.F9Macro;
                userSetting.F10macro = userSettingsDetails.F10Macro;
                userSetting.F11macro = userSettingsDetails.F11Macro;
                userSetting.F12macro = userSettingsDetails.F12Macro;

                await context.SaveChangesAsync();

                // Return the user settings with the values stored in the database.
                return new UserSettingsDetails
                {
                    FontName = userSetting.FontName,
                    FontSize = userSetting.FontSize,
                    F1Macro = userSetting.F1macro,
                    F2Macro = userSetting.F2macro,
                    F3Macro = userSetting.F3macro,
                    F4Macro = userSetting.F4macro,
                    F5Macro = userSetting.F5macro,
                    F6Macro = userSetting.F6macro,
                    F7Macro = userSetting.F7macro,
                    F8Macro = userSetting.F8macro,
                    F9Macro = userSetting.F9macro,
                    F10Macro = userSetting.F10macro,
                    F11Macro = userSetting.F11macro,
                    F12Macro = userSetting.F12macro
                };
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteGameAsync(string gameGuid, string userId)
        {
            Guid guid = Guid.Parse(gameGuid);
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Savedgame? savedGame = await context.Savedgames.SingleOrDefaultAsync(_savedGame => _savedGame.Guid == guid);
                if (savedGame == null)
                    return false;
                context.Savedgames.Remove(savedGame);
                context.Savedgamecontents.Remove(new Savedgamecontent
                {
                    Id = savedGame.SavedGameContentId
                });
                await context.SaveChangesAsync();
                return true;
            }
        }

        /// <inheritdoc/>
        public async Task<AvailableGames> ListGamesAsync(string username)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                SavedGame[] savedGames = await context.Savedgames
                    .Where(_savedGame => _savedGame.Username == username)
                    .Select(_savedGame => new SavedGame()
                    {
                        CharacterName = _savedGame.CharacterName,
                        Comments = _savedGame.Comments,
                        Gold = _savedGame.Gold,
                        Level = _savedGame.Level,
                        Guid = _savedGame.Guid.ToString(),
                        IsAlive = _savedGame.IsAlive,
                        SavedDateTime = _savedGame.DateTime
                    })
                    .ToArrayAsync();
                return new AvailableGames()
                {
                    SavedGames = savedGames,
                    GameRecoveries = new GameRecovery[] { }
                };
            }
        }

        /// <inheritdoc/>
        public async Task<MessageDetails?> WriteMessageAsync(string fromId, string? toId, string content, MessageTypeEnum type, string? gameId)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Message newMessage = new Message()
                {
                    FromUserId = fromId,
                    Content = content,
                    SentDateTime = DateTime.Now,
                    ToUserId = toId,
                    GameId = gameId,
                    Type = (int)type
                };
                context.Messages.Add(newMessage);
                try
                {
                    await context.SaveChangesAsync(true);

                    // Return the message details.
                    MessageDetails message = new MessageDetails
                    {
                        FromId = newMessage.FromUserId,
                        Id = newMessage.Id,
                        Message = newMessage.Content,
                        SentDateTime = newMessage.SentDateTime,
                        Type = (MessageTypeEnum)newMessage.Type
                    };
                    return message;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types, bool includeDeleted)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                context.Database.EnsureCreated();
                IQueryable<Message> messagesQuery = context.Messages;
                if (userId == null)
                    messagesQuery = messagesQuery.Where(_message => _message.ToUserId == null);
                else
                    messagesQuery = messagesQuery.Where(_message => _message.ToUserId == null || _message.ToUserId == userId);
                if (types != null)
                {
                    int[] intTypes = types.Select(_type => (int)_type).ToArray();
                    messagesQuery = messagesQuery.Where(_message => intTypes.Contains(_message.Type));
                }
                IQueryable<MessageDetails> messageDetailsQuery = messagesQuery
                    .OrderByDescending(_message => _message.Id) // We will use the clustered index for sorting.
                    .Take(50) // We are only providing 50 messages.  The user will need to scroll for more.
                    .Select(_message => new MessageDetails // We need to build MessageDetails objects to be returned.
                    {
                        FromId = _message.FromUserId,
                        Id = _message.Id,
                        Message = _message.Content,
                        SentDateTime = _message.SentDateTime,
                        Type = (MessageTypeEnum)_message.Type,

                    })
                    .Reverse(); // The list needs to be reverse for rendering.
                MessageDetails[] messages = await messageDetailsQuery.ToArrayAsync();
                return messages;
            }
        }

        public async Task<bool> DeleteMessagesAsync(int messageId)
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Message? message = context.Messages.SingleOrDefault(_message => _message.Id == messageId);
                if (message is null)
                {
                    return false;
                }
                //message.IsDeleted = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public byte[]? ReadGame(string username, string gameGuid)
        {
            throw new NotImplementedException();
        }

        public bool WriteGame(string username, string gameGuid, GameDetails gameDetails, int gameReplayId, byte[] value)
        {
            throw new NotImplementedException();
        }

        public (GameReplayDetails, int) GetReplay(int gameReplayId)
        {
            throw new NotImplementedException();
        }

        public int GenerateGameReplayGameId(string userId, string gameGuid, int seed)
        {
            throw new NotImplementedException();
        }

        public void WriteStep(int gameReplayId, DateTimeOffset dateTime, char keystroke, int seed, string? stackTrace)
        {
            throw new NotImplementedException();
        }

        public int GetGameReplayId(string gameGuid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGameRecoveryAsync(int gameRecoveryId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
