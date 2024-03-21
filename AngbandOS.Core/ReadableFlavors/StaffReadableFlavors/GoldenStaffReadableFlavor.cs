// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavors;

[Serializable]
internal class GoldenStaffReadableFlavor : StaffReadableFlavor
{
    private GoldenStaffReadableFlavor(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    public override string Name => "Golden";
}
