// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PowerDragonScaleMailItemFactory : ItemFactory
{
    private PowerDragonScaleMailItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
   {
        (100, "3d5-3")
   };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    protected override string? ActivationName => nameof(BallOfElements300r3Activation);
    protected override string SymbolBindingKey => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Power Dragon Scale Mail";
    public override int ArmorClass => 40;
    public override int Cost => 345000;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax  => "Power Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 110;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (110, 64)
    };
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int BonusArmorClass => 15;
    public override int BonusHit => -3;
    public override int Weight => 250;

    /// <summary>
    /// Returns a treasure rating of 30 for dragon scale mail items.
    /// </summary>
    public override int TreasureRating => 30;
    protected override string ItemClassBindingKey => nameof(DragonScaleMailsItemClass);
    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(OnBodyInventorySlot) };
    public override int PackSort => 19;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns true because broken armor should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Armor. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool IsArmor => true;
    public override bool IdentityCanBeSensed => true;
    public override bool IsWearableOrWieldable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleDragonScaleMailEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorDragonScaleMailEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodDragonScaleMailEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatDragonScaleMailEnchantmentScript) })
    };
}
