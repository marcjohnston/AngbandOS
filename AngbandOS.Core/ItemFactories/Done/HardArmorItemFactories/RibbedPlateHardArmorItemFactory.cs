// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RibbedPlateHardItemFactory : ItemFactory
{
    private RibbedPlateHardItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
   {
        (100, "3d5-3")
   };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    protected override string SymbolBindingKey => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Ribbed Plate Armor";

    public override int ArmorClass => 28;
    public override int Cost => 1500;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax  => "Ribbed Plate Armor~";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int BonusHit => -3;
    public override int Weight => 380;
    protected override string ItemClassBindingKey => nameof(HardArmorsItemClass);
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(OnBodyWieldSlot) };
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
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleHardArmorEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorHardArmorEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodHardArmorEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatHardArmorEnchantmentScript) })
    };
}
