// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DoomAmuletItemFactory : ItemFactory
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;    private DoomAmuletItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolBindingKey => nameof(DoubleQuoteSymbol);
    public override string Name => "DOOM";
    protected override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(BrokenAndCursedEnchantmentScript),  nameof(PoorStatsEnchantmentScript), nameof(PoorArmorClass1D5B5EnchantmentScript) })
    };
    public override bool Cha => true;
    public override bool Con => true;
    public override bool IsCursed => true;
    public override bool Dex => true;
    public override bool HideType => true;
    public override bool Int => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int InitialBonusStrength => -5;
    public override int InitialBonusCharisma => -5;
    public override int InitialBonusConstitution => -5;
    public override int InitialBonusIntelligence => -5;
    public override int InitialBonusDexterity => -5;
    public override int InitialBonusWisdom => -5;
    public override bool Str => true;
    public override int Weight => 3;
    public override bool Wis => true;
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
