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
    public class WebSqlPersistentStorage : IWebPersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        public WebSqlPersistentStorage(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
        }

        public async Task<UserSettingsDetails?> GetPreferences(string userId)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                UserSetting? userSetting = await context.UserSettings.SingleOrDefaultAsync(_userSetting => _userSetting.UserId == userId);
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
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                UserSetting? userSetting = await context.UserSettings.SingleOrDefaultAsync(_userSetting => _userSetting.UserId == userId);
                if (userSetting == null)
                {
                    userSetting = new UserSetting();
                    userSetting.UserId = userId;
                    context.UserSettings.Add(userSetting);
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
        public async Task<bool> DeleteAsync(string id, string username)
        {
            Guid guid = Guid.Parse(id);
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = await context.SavedGames.SingleOrDefaultAsync(_savedGame => _savedGame.Username == username && _savedGame.Guid == guid);
                if (savedGame == null)
                    return false;
                context.SavedGames.Remove(savedGame);
                context.SavedGameContents.Remove(new SavedGameContent
                {
                    Id = savedGame.SavedGameContentId
                });
                await context.SaveChangesAsync();
                return true;
            }
        }

        /// <inheritdoc/>
        public async Task<SavedGameDetails[]> ListAsync(string username)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGameDetails[] savedGames = await context.SavedGames
                    .Where(_savedGame => _savedGame.Username == username)
                    .Select(_savedGame => new SavedGameDetails()
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
                return savedGames;
            }
        }

        /// <inheritdoc/>
        public async Task<MessageDetails?> WriteMessageAsync(string fromId, string? toId, string content, MessageTypeEnum type, string? gameId)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
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
        public async Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
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
                        Type = (MessageTypeEnum)_message.Type
                    })
                    .Reverse(); // The list needs to be reverse for rendering.
                MessageDetails[] messages = await messageDetailsQuery.ToArrayAsync();
                return messages;
            }
        }
    }
}
