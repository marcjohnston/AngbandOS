// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PartialPlateHardArmorItemFactory : ItemFactoryGameConfiguration
{
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override string SymbolBindingKey => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Partial Plate Armor";
    public override string? ItemEnhancementBindingKey => nameof(PartialPlateHardArmorItemFactoryItemEnhancement);

    public override int ArmorClass => 22;
    public override int Cost => 1200;
    public override int DamageDice => 1;
    public override int DamageSides => 6;
    public override string? DescriptionSyntax  => "Partial Plate Armor~";
    public override int LevelNormallyFound => 45;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (45, 1)
    };
    public override int BonusHit => -3;
    public override string ItemClassBindingKey => nameof(HardArmorsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.OnBodyWieldSlot) };
    public override int PackSort => 20;
    public override bool HatesAcid => true;
    public override bool CanProvideSheathOfElectricity => true;
    public override bool CanProvideSheathOfFire => true;
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
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleHardArmorEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorHardArmorEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodHardArmorEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatHardArmorEnchantmentScript) })
    };
}
