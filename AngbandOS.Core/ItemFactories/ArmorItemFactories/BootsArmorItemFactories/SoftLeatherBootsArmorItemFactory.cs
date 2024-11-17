// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SoftLeatherBootsArmorItemFactory : ArmorItemFactory
{
    private SoftLeatherBootsArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Pair of Soft Leather Boots";

    public override int ArmorClass => 2;
    public override int Cost => 7;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Pair~ of Soft Leather Boots";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleBootsEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorBootsEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodBootsEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatBootsEnchantmentScript) })
    };

    public override int Weight => 20;
    /// <summary>
    /// Returns the feet inventory slot for boots.
    /// </summary>
    public override int[] WieldSlots => new int[] { InventorySlot.Feet };

    protected override string ItemClassBindingKey => nameof(BootsItemClass);
    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(FeetInventorySlot) };
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override int PackSort => 27;

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
}
