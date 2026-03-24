namespace AngbandOS.Core.Interface;

public interface IReplayPersistentStorage
{
    void WriteStep(DateTime dateTime, char keystroke);
    void NewGame(int seed);
    GameReplayDetails GetReplay(string gameGuid);
}
