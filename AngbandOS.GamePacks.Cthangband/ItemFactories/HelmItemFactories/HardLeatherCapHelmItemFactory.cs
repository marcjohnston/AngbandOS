// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapHelmItemFactory : ItemFactoryGameConfiguration
{
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override int? RandomArtifactBonusArmorCeiling => 19;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override string SymbolBindingKey => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Hard Leather Cap";
    public override string? ItemEnhancementBindingKey => nameof(CanReflectBoltsAndArrowsItemFactoryItemEnhancement);

    public override int ArmorClass => 2;
    public override int Cost => 12;
    public override string? DescriptionSyntax => "Hard Leather Cap~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 15;
    public override string ItemClassBindingKey => nameof(HelmsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.HeadWieldSlot) };
    public override int PackSort => 25;
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
        (new int[] { -2 }, null, new string[] { nameof(SystemScriptsEnum.TerribleHelmEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(SystemScriptsEnum.PoorHelmEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(SystemScriptsEnum.GoodHelmEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(SystemScriptsEnum.GreatHelmEnchantmentScript) })
    };
}
