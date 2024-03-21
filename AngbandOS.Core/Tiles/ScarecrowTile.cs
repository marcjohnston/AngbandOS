// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class ScarecrowTile : Tile
{
    private ScarecrowTile(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    protected override string? AlterActionName => nameof(TunnelAlterAction);
    public override bool BlocksLos => true;
    public override string Description => "scarecrow";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;

    /// <summary>
    /// Returns true, because a scarecrow is considered a tree.
    /// </summary>
    public override bool IsTree => true;
}
