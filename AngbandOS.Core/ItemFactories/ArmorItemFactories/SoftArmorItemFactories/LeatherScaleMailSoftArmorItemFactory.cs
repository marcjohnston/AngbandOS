// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LeatherScaleMailSoftArmorItemFactory : SoftArmorItemFactory
{
    private LeatherScaleMailSoftArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Leather Scale Mail";

    public override int ArmorClass => 11;
    public override int Cost => 450;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Leather Scale Mail~";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override int BonusHit => -1;
    public override int Weight => 140;
    public override Item CreateItem() => new Item(Game, this);
}
