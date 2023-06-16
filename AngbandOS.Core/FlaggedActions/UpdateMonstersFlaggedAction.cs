namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateMonstersFlaggedAction : FlaggedAction
{
    public UpdateMonstersFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        for (int i = 1; i < SaveGame.Level.MMax; i++)
        {
            Monster mPtr = SaveGame.Level.Monsters[i];
            if (mPtr.Race == null)
            {
                continue;
            }
            SaveGame.Level.UpdateMonsterVisibility(i, false);
        }
    }
}