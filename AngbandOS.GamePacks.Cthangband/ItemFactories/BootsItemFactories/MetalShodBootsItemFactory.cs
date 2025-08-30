// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalShodBootsItemFactory : ItemFactoryGameConfiguration
{
    public override string[]? EnhancementFixedArtifactFactoriesBindingKeys => new string[] { nameof(FixedArtifactsEnum.PairOfMetalShodBootsOfTheBlackReaverFixedArtifact) };
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override string SymbolBindingKey => nameof(CloseBraceSymbol);
    public override string Name => "Pair of Metal Shod Boots";

    public override string? DescriptionSyntax => "Pair~ of Metal Shod Boots";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(MetalShodBootsItemFactoryItemEnhancement);

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleBootsEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorBootsEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodBootsEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatBootsEnchantmentScript) })
    };


    public override string ItemClassBindingKey => nameof(BootsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.FeetWieldSlot) };
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
}
