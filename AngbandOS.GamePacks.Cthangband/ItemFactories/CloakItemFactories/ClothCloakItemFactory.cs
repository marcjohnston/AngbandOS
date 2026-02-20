// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ClothCloakItemFactory : ItemFactoryGameConfiguration
{
    public override string[]? EnhancementFixedArtifactFactoriesBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakDarknessFixedArtifact), nameof(FixedArtifactsEnum.CloakOfBarzaiFixedArtifact), nameof(FixedArtifactsEnum.CloakOfTheSwashbucklerFixedArtifact), nameof(FixedArtifactsEnum.CloakShadeFixedArtifact), nameof(FixedArtifactsEnum.CloakShifterFixedArtifact) };
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override string? ItemEnhancementBindingKey => nameof(ClothCloakItemFactoryItemEnhancement);
    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override string SymbolBindingKey => nameof(OpenParenthesisSymbol);
    public override string Name => "Cloth";
    public override string DescriptionSyntax => "Cloak~";

    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1),
        (20, 1)
    };
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleCloakEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorCloakEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodCloakEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatCloakEnchantmentScript) })
    };


    public override string ItemClassBindingKey => nameof(CloaksItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.AboutBodyWieldSlot) };

    public override int PackSort => 22;

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
    public override int RandartActivationChance => base.RandartActivationChance * 2;
    public override bool IsGood => true;
}
