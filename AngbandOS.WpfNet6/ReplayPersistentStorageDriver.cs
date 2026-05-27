using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace Cthangband;

internal class ReplayPersistentStorageDriver : IReplayPersistentStorage, IDisposable
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

        int seed = reader.ReadInt32();

        var steps = new List<GameReplayStep>();

        while (stream.Position < stream.Length)
        {
            long ticks = reader.ReadInt64();
            char c = reader.ReadChar();
            char c2 = reader.ReadChar();
            GameReplayStep gameReplayStep = new GameReplayStep(new DateTime(ticks), c);
            steps.Add(gameReplayStep);
        }

        return new GameReplayDetails(seed, steps.ToArray());
    }
    public GameReplayDetails GetReplay(string gameGuid)
    {
        throw new NotImplementedException();
    }
    public async void NewGame(int seed)
    {
        _stream = new FileStream(ReplayFilename, FileMode.Create, FileAccess.Write, FileShare.Read);
        await WriteIntAsync(seed);
    }
    public async Task WriteIntAsync(int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        await _stream.WriteAsync(bytes);
    }
    public async Task WriteCharAsync(char value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        await _stream.WriteAsync(bytes);
    }

    public async Task WriteDateTimeAsync(DateTime value)
    {
        byte[] bytes = BitConverter.GetBytes(value.Ticks);
        await _stream.WriteAsync(bytes);
    }

    public async void WriteStep(DateTime dateTime, char keystroke)
    {
        // If we are appending data to an existing replay, we need to open it now.
        if (_stream is null)
        {
            _stream = new FileStream(ReplayFilename, FileMode.Append, FileAccess.Write, FileShare.Read);
        }

        await WriteDateTimeAsync(dateTime);
        await WriteCharAsync(keystroke);
        await _stream.FlushAsync();
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
