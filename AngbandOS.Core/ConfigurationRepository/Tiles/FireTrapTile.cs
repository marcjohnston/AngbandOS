// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class FireTrapTile : Tile
{
    private FireTrapTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override string SymbolName => nameof(CaretSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    protected override string? AlterActionName => nameof(DisarmAlterAction);
    public override string Description => "discolored spot";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
    public override void StepOn(GridTile tile)
    {
        // Do 4d6 fire damage
        SaveGame.MsgPrint("You are enveloped in flames!");
        int damage = SaveGame.DiceRoll(4, 6);
        SaveGame.FireDam(damage, "a fire trap");
    }
}
