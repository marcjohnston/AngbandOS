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

        /// <summary>
        /// Returns messages from the database for any specific user.
        /// </summary>
        /// <param name="userId">The id of the user requesting the messages or Null for an anonymous user.</param>
        /// <param name="mostRecentMessageId">The most recent ID of the message to return.  Only messages prior to this ID will be returned.  Used for scrolling.</param>
        /// <param name="types">List of message types that the user should receive or null for ALL.</param>
        /// <returns></returns>
        public async Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
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
