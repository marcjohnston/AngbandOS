// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BarChainMailHardArmorItemFactory : ArmorItemFactory
{
    private BarChainMailHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Bar Chain Mail";

    public override int ArmorClass => 18;
    public override int Cost => 950;
    public override int DamageDice => 1;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax  => "Bar Chain Mail~";
    public override int LevelNormallyFound => 35;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (35, 1)
    };
    public override int BonusHit => -2;
    public override int Weight => 280;
    /// <summary>
    /// Returns the on-body inventory slot for hard armor.
    /// </summary>
    public override int[] WieldSlots => new int[] { InventorySlot.OnBody };

    protected override string ItemClassBindingKey => nameof(HardArmorsItemClass);
    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(OnBodyInventorySlot) };
    public override int PackSort => 20;
    public override bool HatesAcid => true;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;

    public override bool CanReflectBoltsAndArrows => true;
    public override bool CanApplyArtifactBiasResistance => true;

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
        (new int[] { -2 }, null, new string[] { nameof(TerribleHardArmorEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorHardArmorEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodHardArmorEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatHardArmorEnchantmentScript) })
    };
}
