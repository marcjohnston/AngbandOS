using AngbandOS.Core.Interface;
using System.Text;

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

        // Read the game seed.
        int gameSeed = reader.ReadInt32();

        // Read the steps.
        var steps = new List<GameReplayStep>();
        while (stream.Position < stream.Length)
        {
            // Read the date time in clock ticks.
            long ticks = reader.ReadInt64();

            // Read the keystroke.  
            char c = reader.ReadChar();
            char c2 = reader.ReadChar(); // TODO: This will be zero ... but Char is 2 bytes and ReadChar isn't reading it.

            // Read the seed.
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
        await _stream.FlushAsync();
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

    public async Task WriteByteAsync(byte value)
    {
        await _stream.WriteAsync(new byte[] { value });
    }

    public async Task WriteStringAsync(string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        await WriteIntAsync(value.Length);
        await _stream.WriteAsync(bytes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks>This date time consumes 8 bytes.</remarks>
    public async Task WriteDateTimeAsync(DateTimeOffset value)
    {
        byte[] bytes = BitConverter.GetBytes(value.Ticks);
        await _stream.WriteAsync(bytes);
    }

    public async void WriteStep(DateTime dateTime, char keystroke, int seed)
    {
        // If we are appending data to an existing replay, we need to open it now.
        if (_stream is null)
        {
            _stream = new FileStream(ReplayFilename, FileMode.Append, FileAccess.Write, FileShare.Read);
        }

        //TODO: This needs to be converted into a concurrent queue and a separate thread to write the queue records.
        await WriteDateTimeAsync(dateTime);
        await WriteCharAsync(keystroke);
        await WriteIntAsync(seed);
        await _stream.FlushAsync();
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
