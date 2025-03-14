// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LeatherGlovesItemFactory : ItemFactory
{
    private LeatherGlovesItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
   {
        (100, "3d5-3")
   };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    protected override string SymbolBindingKey => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Set of Leather Gloves";

    public override int ArmorClass => 1;
    public override int Cost => 3;
    protected override string? DescriptionSyntax => "Set~ of Leather Gloves";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int Weight => 5;
    protected override string ItemClassBindingKey => nameof(GlovesItemClass);

    public override int PackSort => 26;
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(HandsWieldSlot) };
    public override bool HatesFire => true;
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
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleGlovesEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorGlovesEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodGlovesEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatGlovesEnchantmentScript) })
    };
}
