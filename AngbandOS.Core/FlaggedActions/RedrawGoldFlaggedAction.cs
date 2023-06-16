
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawGoldFlaggedAction : FlaggedAction
{
    private const int ColGold = 0;
    private const int RowGold = 11;
    public RedrawGoldFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.Screen.Print("GP ", RowGold, ColGold);
        string tmp = SaveGame.Player.Gold.ToString().PadLeft(9);
        SaveGame.Screen.Print(Colour.BrightGreen, tmp, RowGold, ColGold + 3);
    }
}
