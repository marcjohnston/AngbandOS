// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class QuartzTile : Tile
{
    private QuartzTile(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(PoundSignSymbol);
    protected override string? AlterActionName => nameof(TunnelAlterAction);
    public override bool BlocksLos => true;
    protected override string? VisibleTreasureForTileName => nameof(QuartzVisibleTreasureTile);
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    /// <summary>
    /// Returns true because this tile is a vein.
    /// </summary>
    public override bool IsVein => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;

}
