// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlayingRingItemFactory : ItemFactory
{
    private SlayingRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override string Name => "Slaying";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    protected override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(BrokenAndCursedEnchantmentScript), nameof(PoorDamage1D7P10BEnchantmentScript), nameof(PoorHit1D7P10BEnchantmentScript) }),
        (new int[] {0, 1, 2}, null, new string[] { nameof(BonusDamage1D7P10BEnchantmentScript), nameof(BonusHit1D7P10BEnchantmentScript) })
    };

    public override int Cost => 1000;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 2;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string ItemClassBindingKey => nameof(RingsItemClass);

    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(RightHandInventorySlot), nameof(LeftHandInventorySlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}