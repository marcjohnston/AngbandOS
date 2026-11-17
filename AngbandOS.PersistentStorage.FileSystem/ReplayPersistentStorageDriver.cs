using AngbandOS.Core.Interface;
using System.Text;
using System.Buffers.Binary;

namespace AngbandOS.PersistentStorage.FileSystem;

public class ReplayPersistentStorageDriver : IReplayPersistentStorage, IDisposable
{
    // The filename.
    private string ReplayFilename { get; }

    // Define the header for the continuous replay format.
    private const string ReplayHeader = "-----BEGIN ANGBANDOS REPLAY-----";

    // The open stream used to write the replay data.
    private FileStream _stream = null!;

    // Whether the replay uses the continuous text format.
    private bool _isTextReplay;

    // The bytes from the final incomplete Base64 group.
    private byte[] _tail = Array.Empty<byte>();

    public ReplayPersistentStorageDriver(string replayFilename)
    {
        ReplayFilename = replayFilename;
    }

    /// <summary>
    /// Loads the starting seed and recorded steps from a binary or continuous Base64 replay.
    /// </summary>
    /// <returns>GameReplayDetails</returns>
    public GameReplayDetails GetReplay()
    {
        // Open the replay file for reading until method finishes.
        using var stream = new FileStream(
            ReplayFilename,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite);

        if (IsTextReplay(stream))
        {
            byte[] bytes = ReadContinuousPayload(stream);
            var replaySteps = new List<GameReplayStep>();

            for (int offset = 4; offset < bytes.Length; offset += 14)
            {
                replaySteps.Add(DecodeStep(bytes.AsSpan(offset, 14)));
            }

            // Read the starting seed from the first four bytes.
            int startingSeed = BinaryPrimitives.ReadInt32LittleEndian(bytes);
            
            return new GameReplayDetails(startingSeed, replaySteps.ToArray());
        }

        // If there aren't enough bytes for a seed and at least one step, the replay is invalid.
        if (stream.Length < 4 || (stream.Length - 4) % 14 != 0)
        {
            throw new FormatException("Invalid binary replay length.");
        }

        // Create a reader around existing stream to read the starting seed and steps.
        using var reader = new BinaryReader(stream);

        // Read the first four bytes as the starting seed.
        int gameSeed = reader.ReadInt32();

        // Create an empty list for the original binary file's steps.
        var steps = new List<GameReplayStep>();

        while (stream.Position < stream.Length)
        {
            // Read the next 14 bytes as a replay step.
            long ticks = reader.ReadInt64();
            char keystroke = (char)reader.ReadUInt16();
            int stepSeed = reader.ReadInt32();

            // Create a new GameReplayStep object and add it to the list.
            GameReplayStep step = new GameReplayStep(new DateTime(ticks), keystroke, stepSeed);
            steps.Add(step);
        }
        
        return new GameReplayDetails(gameSeed, steps.ToArray());
    }

    /// <summary>
    /// Creates a new replay file and writes its header and starting seed.
    /// </summary>
    /// <param name="seed">The starting seed for the game.</param>
    public void NewGame(int seed)
    {
        // Dispose any existing stream before creating a new one.
        _stream?.Dispose();

        // Create a new file stream for writing the replay data.
        _stream = new FileStream(ReplayFilename, FileMode.Create, FileAccess.Write, FileShare.Read);

        // Set the flag to indicate that this is a text replay(Base64 encoded).
        _isTextReplay = true;

        // Reset the tail to an empty array for a new game.
        _tail = Array.Empty<byte>();

        // Write the replay header to the file.
        _stream.Write(Encoding.ASCII.GetBytes(ReplayHeader + "\n"));
        byte[] bytes = new byte[4];
        BinaryPrimitives.WriteInt32LittleEndian(bytes, seed);
        WriteContinuous(bytes);
        _stream.Flush();
    }

    /// <summary>
    /// Records a timestamp, keystroke, and seed using the replay file's existing format.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="keystroke"></param>
    /// <param name="seed"></param>
    public void WriteStep(DateTime dateTime, char keystroke, int seed)
    {
        if (_stream is null)
        {
             // Validate that the replay exists before attempting to write a step.
             GetReplay();

             using (var existingReplay = new FileStream(ReplayFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
             {
                 _isTextReplay = IsTextReplay(existingReplay);

                 if (_isTextReplay)
                 {
                     // Read the existing replay data to determine the tail for Base64 encoding.
                     byte[] bytes = ReadContinuousPayload(existingReplay);
                     int tailLength = bytes.Length % 3;
                     _tail = bytes.AsSpan(bytes.Length - tailLength).ToArray();
                 }
             }
             _stream = new FileStream(ReplayFilename, FileMode.Open, FileAccess.Write, FileShare.Read);

             _stream.Seek(0, SeekOrigin.End);
        }
        // Create a new GameReplayStep object with the provided parameters.
        var step = new GameReplayStep(dateTime, keystroke, seed);
        byte[] stepBytes = EncodeStep(step);

        if (_isTextReplay)
        {
            WriteContinuous(stepBytes);
        }
        else
        {           
            _stream.Write(stepBytes);
        }
        // Flush the stream to ensure that the data is written to the file.
        _stream.Flush();
    }

    /// <summary>
    /// Extends the unpadded Base64 payload by re-encoding the final incomplete group with the new bytes.
    /// </summary>
    /// <param name="bytes"></param>
    private void WriteContinuous(byte[] bytes)
    {
        int tailCharacters = _tail.Length == 0 ? 0 : _tail.Length + 1;
        _stream.Seek(-tailCharacters, SeekOrigin.Current);
        byte[] combined = new byte[_tail.Length + bytes.Length];
        _tail.CopyTo(combined, 0);
        bytes.CopyTo(combined, _tail.Length);
        string encoded = Convert.ToBase64String(combined).TrimEnd('=');
        _stream.Write(Encoding.ASCII.GetBytes(encoded));
        int tailLength = combined.Length % 3;
        _tail = combined.AsSpan(combined.Length - tailLength).ToArray();

    }

    /// <summary>
    /// Closes the replay writing stream if it is open.
    /// </summary>
    public void Dispose()
    {
        _stream?.Dispose();
    }

    /// <summary>
    /// Packs a step's timestamp, keystroke, and seed into a 14-byte record.
    /// </summary>
    /// <param name="step"></param>
    /// <returns></returns>
    private static byte[] EncodeStep(GameReplayStep step)
    {
        byte[] bytes = new byte[14];
        BinaryPrimitives.WriteInt64LittleEndian(bytes, step.DateTime.Ticks);
        BinaryPrimitives.WriteUInt16LittleEndian(bytes.AsSpan(8), step.Keystroke);
        BinaryPrimitives.WriteInt32LittleEndian(bytes.AsSpan(10), step.Seed);
        return bytes;
    }

    /// <summary>
    /// Validates a 14-byte replay record and reconstructs its timestamp, keystroke, and seed.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    private static GameReplayStep DecodeStep(ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length != 14)
        {
           throw new FormatException("A replay step must contain exactly 14 bytes.");
        }
           
        long ticks = BinaryPrimitives.ReadInt64LittleEndian(bytes);

        if (ticks < DateTime.MinValue.Ticks || ticks > DateTime.MaxValue.Ticks)
        {
            throw new FormatException("Invalid replay timestamp.");
        }

        char keystroke = (char)BinaryPrimitives.ReadUInt16LittleEndian(bytes.Slice(8));
        int seed = BinaryPrimitives.ReadInt32LittleEndian(bytes.Slice(10));

        return new GameReplayStep(new DateTime(ticks), keystroke, seed);
    }

    /// <summary>
    /// Checks the replay header, decodes the unpadded Base64 payload, and validates its byte layout.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    private static byte[] ReadContinuousPayload(Stream stream)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, leaveOpen: true);

        if (reader.ReadLine() != ReplayHeader)
        {
            throw new FormatException("Unsupported replay header.");
        }
            
        string encoded = reader.ReadToEnd();

        if (encoded.Any(c => !(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || c == '+' || c == '/')))
        {
            throw new FormatException("Replay payload must contain only unpadded Base64 characters.");
        }
        
        int paddingLength = (4 - (encoded.Length % 4)) % 4;
        string padded = encoded + new string('=', paddingLength);
        byte[] bytes = Convert.FromBase64String(padded);

        if (bytes.Length < 4 || (bytes.Length - 4) % 14 != 0)
        {
            throw new FormatException("Replay must contain a four-byte seed followed by 14-byte steps.");
        }

        if (Convert.ToBase64String(bytes).TrimEnd('=') != encoded)
        {
            throw new FormatException("Replay payload is not canonical Base64.");
        }

        return bytes;
    }

    /// <summary>
    /// Checks for the continuous replay header and restores the stream to its original position.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    private static bool IsTextReplay(Stream stream)
    {
        long position = stream.Position;

        using var reader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);

        byte[] headerBytes = reader.ReadBytes(ReplayHeader.Length + 1);
        stream.Position = position;

        string prefix = Encoding.ASCII.GetString(headerBytes);

        if (prefix == ReplayHeader + "\n")
        {
            return true;
        }

        return false;
    }
}
