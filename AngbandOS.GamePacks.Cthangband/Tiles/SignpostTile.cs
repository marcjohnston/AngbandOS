// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SignpostTile : TileGameConfiguration
{
    public override string SymbolName => nameof(ColonSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string? AlterActionName => nameof(AlterActionsEnum.TunnelAlterAction);
    public override string Description => "signpost";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;

    /// <summary>
    /// Returns true, because a signpost is considered a tree.
    /// </summary>
    public override bool IsTree => true;
}
