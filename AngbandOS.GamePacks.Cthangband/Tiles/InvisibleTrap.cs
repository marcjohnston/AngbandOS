// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class InvisibleTrap : TileGameConfiguration
{
    public override string SymbolName => nameof(PeriodSymbol);
    public override string Description => "invisible trap";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
    public override bool IsInvisibleTrap => true;

    /// <summary>
    /// Returns true because this tile is an unidentified trap.
    /// </summary>
    public override bool IsUnidentifiedTrap => true;
}
