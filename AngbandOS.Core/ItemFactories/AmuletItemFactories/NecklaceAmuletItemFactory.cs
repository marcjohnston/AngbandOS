// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NecklaceAmuletItemFactory : ItemFactory
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;    private NecklaceAmuletItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(DoubleQuoteSymbol);
    public override string Name => "Dwarves";
    protected override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    public override int Cost => 75000;
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 70;
    public override int Weight => 3;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because amulets are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string ItemClassBindingKey => nameof(AmuletsItemClass);
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(NeckWieldSlot) };
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override ColorEnum Color => ColorEnum.Orange;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
