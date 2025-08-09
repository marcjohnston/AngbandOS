// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftStuddedLeatherSoftArmorItemFactory : ItemFactoryGameConfiguration
{
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
   {
        (100, "3d5-3")
   };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override string SymbolBindingKey => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Soft Studded Leather";

    public override int ArmorClass => 5;
    public override int DamageSides => 1;
    public override string? DescriptionSyntax  => "Soft Studded Leather~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(SoftStuddedLeatherSoftArmorItemFactoryItemEnhancement);


    public override string ItemClassBindingKey => nameof(SoftArmorsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.OnBodyWieldSlot) };
    public override int PackSort => 21;
    public override bool HatesFire => true;
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
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleSoftArmorEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorSoftArmorEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodSoftArmorEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatSoftArmorEnchantmentScript) })
    };
}
