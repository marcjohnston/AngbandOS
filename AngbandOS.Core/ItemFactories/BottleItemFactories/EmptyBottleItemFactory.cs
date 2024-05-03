// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EmptyBottleItemFactory : BottleItemFactory
{
    private EmptyBottleItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Empty Bottle";

    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Empty Bottle~";
    public override int Weight => 2;
}
