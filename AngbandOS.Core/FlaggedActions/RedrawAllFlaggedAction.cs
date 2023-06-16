
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawAllFlaggedAction : FlaggedAction
{
    public RedrawAllFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.MsgPrint(null);
        SaveGame.Screen.Clear();
    }
}
