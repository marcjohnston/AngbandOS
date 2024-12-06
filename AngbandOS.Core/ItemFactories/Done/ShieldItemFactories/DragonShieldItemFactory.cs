// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonShieldItemFactory : ItemFactory
{
    private DragonShieldItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
   {
        (100, "3d5-3")
   };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    protected override string SymbolBindingKey => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Shield";

    /// <summary>
    /// Returns a treasure rating of 5 for a shield of dragon scale mail.
    /// </summary>
    public override int TreasureRating => 5;
    public override int ArmorClass => 8;
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    protected override string? DescriptionSyntax => "Dragon Shield~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 4)
    };
    public override int BonusArmorClass => 10;
    public override int Weight => 100;

    protected override string ItemClassBindingKey => nameof(ShieldsItemClass);
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(ArmWieldSlot) };
    public override int PackSort => 23;
    public override bool HatesAcid => true;

    public override bool CanReflectBoltsAndArrows => true;

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
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleShieldEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorShieldEnchantmentScript) }),
        (null, null, new string[] { nameof(DragonResistanceEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodShieldEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatShieldEnchantmentScript) })
    };
}
