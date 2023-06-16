namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateDistancesFlaggedAction : FlaggedAction
{
    public UpdateDistancesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        for (int i = 1; i < SaveGame.Level.MMax; i++)
        {
            Monster mPtr = SaveGame.Level.Monsters[i];
            if (mPtr.Race == null)
            {
                continue;
            }
            SaveGame.Level.UpdateMonsterVisibility(i, true);
        }
    }
}