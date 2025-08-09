// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonShieldItemFactory : ItemFactoryGameConfiguration
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
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Shield";

    public override string? ItemEnhancementBindingKey => nameof(DragonShieldItemFactoryItemEnhancement);
    public override int ArmorClass => 8;
    public override int DamageSides => 3;
    public override string? DescriptionSyntax => "Dragon Shield~";
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 4)
    };
    public override int BonusArmorClass => 10;

    public override string ItemClassBindingKey => nameof(ShieldsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.ArmWieldSlot) };
    public override int PackSort => 23;
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
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleShieldEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorShieldEnchantmentScript) }),
        (null, null, new string[] { nameof(SystemScriptsEnum.DragonResistanceEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodShieldEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatShieldEnchantmentScript) })
    };
}
