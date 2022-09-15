using AngbandOS.Web.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int?> WriteMessageAsync(string fromId, string? toId, string content, DateTime sentDateTime, MessageTypeEnum type)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                Message newMessage = new Message()
                {
                    FromUserId = fromId,
                    Content = content,
                    SentDateTime = sentDateTime,
                    ToUserId = toId,
                    Type = (int)type
                };
                context.Messages.Add(newMessage);
                try
                {
                    await context.SaveChangesAsync(true);

                    // Return the unique ID for the message.
                    return newMessage.Id;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                return await context.Messages
                    .Where(_message => _message.ToUserId == userId)
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
                    .Reverse() // The list needs to be reverse for rendering.
                    .ToArrayAsync();
            }
        }
    }
}
