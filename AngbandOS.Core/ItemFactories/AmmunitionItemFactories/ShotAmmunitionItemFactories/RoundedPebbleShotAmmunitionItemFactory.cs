// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RoundedPebbleShotAmmunitionItemFactory : ShotAmmunitionItemFactory
{
    private RoundedPebbleShotAmmunitionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Rounded Pebble";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "& Rounded Pebble~";
    public override bool ShowMods => true;
    public override int Weight => 4;
    public override Item CreateItem() => new Item(Game, this);
}
