using AngbandOS.Core.Interface;

namespace AngbandOS.PersistentStorage.FileSystem;

public class ReplayPersistentStorageDriver : IReplayPersistentStorage, IDisposable
{
    private string ReplayFilename { get; }
    private FileStream _stream;
    public ReplayPersistentStorageDriver(string replayFilename)
    {
        ReplayFilename = replayFilename;
    }
    public GameReplayDetails GetReplay()
    {
        using var stream = new FileStream(ReplayFilename, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(stream);

        int gameSeed = reader.ReadInt32();

        var steps = new List<GameReplayStep>();

        while (stream.Position < stream.Length)
        {
            long ticks = reader.ReadInt64();
            char c = reader.ReadChar();
            char c2 = reader.ReadChar();
            int stepSeed = reader.ReadInt32();
            GameReplayStep gameReplayStep = new GameReplayStep(new DateTime(ticks), c, stepSeed);
            steps.Add(gameReplayStep);
        }

        return new GameReplayDetails(gameSeed, steps.ToArray());
    }
    public GameReplayDetails GetReplay(string gameGuid)
    {
        throw new NotImplementedException();
    }
    public async void NewGame(int seed)
    {
        _stream = new FileStream(ReplayFilename, FileMode.Create, FileAccess.Write, FileShare.Read);
        await WriteIntAsync(seed);
#if DEBUG
        await _stream.FlushAsync();
#endif
    }
    public async Task WriteIntAsync(int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        await _stream.WriteAsync(bytes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks>This char consumes 2 bytes.</remarks>
    public async Task WriteCharAsync(char value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        await _stream.WriteAsync(bytes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks>This date time consumes 8 bytes.</remarks>
    public async Task WriteDateTimeAsync(DateTime value)
    {
        byte[] bytes = BitConverter.GetBytes(value.Ticks);
        await _stream.WriteAsync(bytes);
    }

    public async void WriteStep(DateTime dateTime, char keystroke, int? seed)
    {
        // If we are appending data to an existing replay, we need to open it now.
        if (_stream is null)
        {
            _stream = new FileStream(ReplayFilename, FileMode.Append, FileAccess.Write, FileShare.Read);
        }

        await WriteDateTimeAsync(dateTime);
        await WriteCharAsync(keystroke);
        await WriteIntAsync(seed ?? -1);
#if DEBUG
        await _stream.FlushAsync();
#endif
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
