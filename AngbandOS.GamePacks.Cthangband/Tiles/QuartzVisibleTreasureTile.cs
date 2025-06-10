// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuartzVisibleTreasureTile : TileGameConfiguration
{
    public override string SymbolName => nameof(AsteriskSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string? AlterActionName => nameof(AlterActionsEnum.TunnelAlterAction);
    public override string? MimicTileName => nameof(QuartzVisibleTreasureTile);
    public override bool BlocksLos => true;
    public override bool IsTreasure => true;

    public override bool IsVisibleTreasure => true;
    public override string Description => "quartz vein with treasure";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 19;
    public override bool RunPast => true;

    /// <summary>
    /// Returns true because this tile is a vein.
    /// </summary>
    public override bool IsVein => true;
}
