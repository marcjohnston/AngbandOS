using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using AngbandOS.Web.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AngbandOS.PersistentStorage;

/// <summary>
/// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
/// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
/// </summary>
public class SqlWebPersistentStorage : IWebPersistentStorage
{
    /// <summary>
    /// Returns the connection string to the database.
    /// </summary>
    protected string ConnectionString { get; }

    public SqlWebPersistentStorage(IConfiguration configuration)
    {
        ConnectionString = configuration["ConnectionString"];
    }

    public async Task EnsureCreated()
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            await context.Database.EnsureCreatedAsync();
        }
    }

    public byte[]? ReadGame(string userId, string gameGuid)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            Sql.Entities.SavedGame? savedGame = context.SavedGames
                .Include(_savedGame => _savedGame.SavedGameContent)
                .SingleOrDefault(_savedGame => _savedGame.UserId == userId && _savedGame.Guid.ToString() == gameGuid);
            if (savedGame == null)
            {
                return null;
            }
            return savedGame.SavedGameContent.Data;
        }
    }

    public bool WriteGame(string userId, string gameGuid, GameDetails gameDetails, byte[] value)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            // Retrieve an existing game from the database.
            Sql.Entities.SavedGame? savedGame = context.SavedGames.SingleOrDefault(_savedGame => _savedGame.UserId == userId && _savedGame.Guid.ToString() == gameGuid);

            // Check to see if it exists.
            if (savedGame is null)
            {
                // Create a new one and add it to the table.
                savedGame = new Sql.Entities.SavedGame()
                {
                    UserId = userId,
                    Guid = Guid.Parse(gameGuid),
                    SavedGameContent = new SavedGameContent()
                    {
                        Data = value
                    }
                };
                context.SavedGames.Add(savedGame);
            }
            else
            {
                // We do not want to read the saved game contents but we need an update.  Build a new record, set the serialized data and mark the record as modified.
                SavedGameContent modifiedSaveGameContent = new SavedGameContent
                {
                    Id = savedGame.SavedGameContentId,
                    Data = value
                };

                context.SavedGameContents.Attach(modifiedSaveGameContent);
                context.Entry(modifiedSaveGameContent).Property(x => x.Data).IsModified = true;
               
            }
            savedGame.CharacterName = gameDetails.CharacterName;
            savedGame.Comments = gameDetails.Comments;
            savedGame.Level = gameDetails.Level;
            savedGame.DateTime = DateTime.Now;
            savedGame.Gold = gameDetails.Gold;
            savedGame.IsAlive = gameDetails.IsAlive;

            context.SaveChanges();
        }
        return true;
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
    public async Task<bool> DeleteGameAsync(string gameGuid, string userId)
    {
        Guid guid = Guid.Parse(gameGuid);
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            // The delete needs to happen as a transaction.
            Sql.Entities.SavedGame? savedGame = await context.SavedGames.SingleOrDefaultAsync(_savedGame => _savedGame.Guid == guid && _savedGame.UserId == userId);
            if (savedGame == null)
            {
                return false;
            }
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
    public async Task<AvailableGames> ListGamesAsync(string userId)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            // Load all of the saved games, but default the replay id to null because it isn't foreign keyed, by design, so we can't reference it easily.
            Web.Interface.SavedGame[] savedGames = await context.SavedGames
                .Where(_savedGame => _savedGame.UserId == userId)
                .Select(_savedGame => new Web.Interface.SavedGame()
                {
                    CharacterName = _savedGame.CharacterName,
                    Comments = _savedGame.Comments,
                    Gold = _savedGame.Gold,
                    Level = _savedGame.Level,
                    Guid = _savedGame.Guid.ToString(),
                    IsAlive = _savedGame.IsAlive,
                    SavedDateTime = _savedGame.DateTime,
                    GameRecoveryId = null // We set this in the next step.  This isn't foreign keyed for us to retrieve this right now.
                })
                .ToArrayAsync();

            // Now load the replay id's for existing games.  Start by gathering the game guid's for a batch lookup.
            string[] savedGameGuids = savedGames.Select(_savedGame => _savedGame.Guid).ToArray();

            // Batch lookup against the database.  Return a dictionary for fast lookup.
            Dictionary<string, int> replayLookup = context.GameRecoveries
                .Where(_gameRecovery => savedGameGuids.Contains(_gameRecovery.GameGuid.ToString()))
                .Select(_gameRecovery => new { _gameRecovery.GameGuid, _gameRecovery.Id })
                .ToDictionary(_dictionary => _dictionary.GameGuid.ToString().ToUpper(), _dictionary => _dictionary.Id);

            // Update the saved games with the associated game recovery ID.
            foreach (var savedGame in savedGames)
            {
                savedGame.GameRecoveryId = replayLookup.TryGetValue(savedGame.Guid, out var id) ? id : null;
            }
            
            // Retrieve orphaned game recoveries.
            Web.Interface.GameRecovery[] recoveryGames = await context.GameRecoveries
                .Where(_gameRecovery => !savedGameGuids.Contains(_gameRecovery.GameGuid.ToString()) && _gameRecovery.UserId == userId)
                .Select(_gameReplay => new Web.Interface.GameRecovery()
                    {
                        Id = _gameReplay.Id,
                        LastPlayedDateTime = _gameReplay.LastPlayed
                    })
                .ToArrayAsync();
            return new AvailableGames()
            {
                SavedGames = savedGames,
                GameRecoveries = recoveryGames
            };
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
    public async Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types, bool includeDeleted)
    {
        await EnsureCreated();
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
                .Where(_message => includeDeleted || !_message.IsDeleted)
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

    public async Task<bool> DeleteMessagesAsync(int messageId)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            Message? message = context.Messages.SingleOrDefault(_message => _message.Id == messageId);
            if (message is null)
            {
                return false;
            }
            message.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> DeleteGameRecoveryAsync(int gameRecoveryId, string userId)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            // We need an explicit transaction for the ExecuteDeleteAsync
            await using var transaction = await context.Database.BeginTransactionAsync();

            Sql.Entities.GameRecovery? gameRecovery = await context.GameRecoveries.SingleOrDefaultAsync(_gameRecovery => _gameRecovery.Id == gameRecoveryId && _gameRecovery.UserId == userId);
            if (gameRecovery == null)
            {
                return false;
            }
            context.GameRecoveries.Remove(gameRecovery);
            await context.ReplaySteps.Where(_replayStep => _replayStep.GameReplayId == gameRecoveryId).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }

    public (GameReplayDetails, int) GetReplay(int gameReplayId)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            // Retrieve the game replay step from the database.
            Sql.Entities.GameRecovery? gameReplay = context.GameRecoveries
                .Include(_gameReplay => _gameReplay.ReplaySteps)
                .SingleOrDefault(_gameReplay => _gameReplay.Id == gameReplayId);
            if (gameReplay == null)
            {
                throw new InvalidOperationException($"No replay found for game guid {gameReplayId}");
            }

            // Retrieve all of the game replay steps, in order and convert them into the interface GameReplayStep objects
            GameReplayStep[] replaySteps = gameReplay.ReplaySteps
                .OrderBy(_replayStep => _replayStep.Id)
                .Select(_replayStep => new GameReplayStep(_replayStep.DateTime, _replayStep.Keystroke[0], _replayStep.Seed, _replayStep.StackTrace))
                .ToArray();
            return (new GameReplayDetails(gameReplay.Seed, replaySteps), gameReplayId);
        }
    }

    public int GenerateGameReplayGameId(string gameGuid, int seed)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            Sql.Entities.GameRecovery newGameReplay = new Sql.Entities.GameRecovery
            {
                GameGuid = Guid.Parse(gameGuid),
                Seed = seed,
                LastPlayed = DateTime.Now
            };
            context.GameRecoveries.Add(newGameReplay);
            context.SaveChanges();
            int gameReplayId = newGameReplay.Id;
            return gameReplayId;
        }
    }

    public void WriteStep(int gameReplayId, DateTime dateTime, char keystroke, int seed, string? stackTrace)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            context.ReplaySteps.Add(new ReplayStep
            {
                GameReplayId = gameReplayId,
                DateTime = dateTime,
                Keystroke = keystroke.ToString(),
                Seed = seed,
                StackTrace = stackTrace
            });
            context.SaveChanges();
        }
    }

    public int GetGameReplayId(string gameGuid)
    {
        using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
        {
            int gameReplayId = context.GameRecoveries.Single(_gameReplay => _gameReplay.GameGuid.ToString() == gameGuid).Id;
            return gameReplayId;
        }
    }
}
