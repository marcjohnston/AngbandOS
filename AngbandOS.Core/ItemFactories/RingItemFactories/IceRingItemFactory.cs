// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IceRingItemFactory : ItemFactory
{
    private IceRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string? ActivationName => nameof(BallOfCold50r2Every1d20p20DirectionalActivation);
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(BonusArmorClass1D5P10BP5EnchantmentScript) })
    };
    protected override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override string Name => "Ice";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override int Cost => 3000;
    public override bool IgnoreCold => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override bool ResCold => true;
    public override int BonusArmorClass => 15;
    public override int Weight => 2;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string ItemClassBindingKey => nameof(RingsItemClass);

    protected override string[] WieldSlotBindingKeys => new string[] { nameof(RightHandWieldSlot), nameof(LeftHandWieldSlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
