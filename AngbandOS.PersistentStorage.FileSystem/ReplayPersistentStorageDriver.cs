using AngbandOS.Core.Interface;
using System.Text;

namespace AngbandOS.PersistentStorage.FileSystem;

public class ReplayPersistentStorageDriver : IReplayPersistentStorage, IDisposable
{
    private string ReplayFilename { get; }
    private FileStream _stream;
    private bool _isTextReplay;
    public ReplayPersistentStorageDriver(string replayFilename)
    {
        ReplayFilename = replayFilename;
    }
    public GameReplayDetails GetReplay()
    {
        using var stream = new FileStream(ReplayFilename, FileMode.Open, FileAccess.Read);

        if (IsTextReplay(stream))
        {
            return ReadTextReplay(stream);
        }

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
    public void NewGame(int seed)
    {
        _stream = new FileStream(
            ReplayFilename,
            FileMode.Create,
            FileAccess.Write,
            FileShare.Read);

        _isTextReplay = true;

        string encodedSeed = Convert.ToBase64String(BitConverter.GetBytes(seed));

        byte[] headerBytes = Encoding.UTF8.GetBytes("ANG1:" + encodedSeed + "\n");

        _stream.Write(headerBytes, 0, headerBytes.Length);
        _stream.Flush();
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

    public void WriteStep(DateTime dateTime, char keystroke, int seed)
    {
        if (_stream is null)
        {
            using (var existingReplay = File.OpenRead(ReplayFilename))
            {
                _isTextReplay = IsTextReplay(existingReplay);
            }

            _stream = new FileStream(
                ReplayFilename,
                FileMode.Append,
                FileAccess.Write,
                FileShare.Read);
        }

        if (_isTextReplay)
        {
            GameReplayStep step = new GameReplayStep(dateTime, keystroke, seed);

            string encodedStep = EncodeStep(step);
            WriteReplayLine(encodedStep);
        }
        else
        {
            _stream.Write(BitConverter.GetBytes(dateTime.Ticks));
            _stream.Write(BitConverter.GetBytes(keystroke));
            _stream.Write(BitConverter.GetBytes(seed));
        }

        _stream.Flush();
    }

    public void Dispose()
    {
        _stream?.Dispose();
    }

    private static string EncodeStep(GameReplayStep step)
    {
        // Create a byte array to hold the encoded step.  The size of the array is 8 bytes for the DateTime, 2 bytes for the char, and 4 bytes for the int.
        byte[] stepBytes = new byte[8 + 2 + 4];

        // Encode the step into a byte array.
        BitConverter.GetBytes(step.DateTime.Ticks).CopyTo(stepBytes, 0);
        BitConverter.GetBytes(step.Keystroke).CopyTo(stepBytes, 8);
        BitConverter.GetBytes(step.Seed).CopyTo(stepBytes, 10);

        // Convert the byte array to a base64 string for storage or transmission.
        return Convert.ToBase64String(stepBytes);
    }

    private static GameReplayStep DecodeStep(string encodedStep)
    {
        byte[] stepBytes = Convert.FromBase64String(encodedStep);

        if (stepBytes.Length != 14)
        {
            throw new FormatException("A replay step must contain exactly 14 bytes.");
        }

        long ticks = BitConverter.ToInt64(stepBytes, 0);
        char keystroke = BitConverter.ToChar(stepBytes, 8);
        int seed = BitConverter.ToInt32(stepBytes, 10);

        return new GameReplayStep(new DateTime(ticks), keystroke, seed);
    }

    private static GameReplayDetails ReadTextReplay(Stream stream)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8);

        string? header = reader.ReadLine();

        if (header is null ||
            !header.StartsWith("ANG1:", StringComparison.Ordinal))
        {
            throw new FormatException("Unsupported replay header.");
        }

        byte[] seedBytes = Convert.FromBase64String(header.Substring(5));

        if (seedBytes.Length != 4)
        {
            throw new FormatException("The starting seed must contain four bytes.");
        }

        int gameSeed = BitConverter.ToInt32(seedBytes, 0);

        var steps = new List<GameReplayStep>();
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            steps.Add(DecodeStep(line));
        }

        return new GameReplayDetails(gameSeed, steps.ToArray());
    }

    private static bool IsTextReplay(Stream stream)
    {
        long originalPosition = stream.Position;

        using var reader = new BinaryReader(
            stream, Encoding.UTF8, leaveOpen: true);

        byte[] headerBytes = reader.ReadBytes(5);
        stream.Position = originalPosition;

        return Encoding.ASCII.GetString(headerBytes) == "ANG1:";
    }

    private void WriteReplayLine(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text + "\n");
        _stream.Write(bytes, 0, bytes.Length);
    }
}
