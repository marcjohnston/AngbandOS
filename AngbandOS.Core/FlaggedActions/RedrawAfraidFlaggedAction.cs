
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawAfraidFlaggedAction : FlaggedAction
{
    private const int ColAfraid = 25;
    private const int RowAfraid = 44;
    public RedrawAfraidFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.Player.TimedFear.TurnsRemaining > 0)
        {
            SaveGame.Screen.Print(Colour.Orange, "Afraid", RowAfraid, ColAfraid);
        }
        else
        {
            SaveGame.Screen.Print("      ", RowAfraid, ColAfraid);
        }
    }
}
