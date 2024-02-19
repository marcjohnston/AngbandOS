// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class ConfuseGasTile : Tile
{
    private ConfuseGasTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override string SymbolName => nameof(CaretSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    protected override string? AlterActionName => nameof(DisarmAlterAction);
    public override string Description => "gas trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
    public override void StepOn(GridTile tile)
    {
        // Confuse the player
        SaveGame.MsgPrint("A gas of scintillating colors surrounds you!");
        if (!SaveGame.HasConfusionResistance)
        {
            SaveGame.TimedConfusion.AddTimer(SaveGame.RandomLessThan(20) + 10);
        }
    }
}
