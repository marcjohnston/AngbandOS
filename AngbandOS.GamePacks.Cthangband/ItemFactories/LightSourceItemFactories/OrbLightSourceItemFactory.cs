// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbLightSourceItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns true because orbs of light should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override string Name => "Orb";

    public override string? ItemEnhancementBindingKey => nameof(OrbLightSourceItemFactoryItemEnhancement);

    public override bool IdentityCanBeSensed => true;

    public override string? DescriptionSyntax => "Orb~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Orbs of light. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;

    public override string ItemClassBindingKey => nameof(LightSourcesItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.LightsourceWieldSlot) };

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(SystemScriptsEnum.PoorOrbOfLightEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(SystemScriptsEnum.GoodOrbOfLightEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatOrbOfLightEnchantmentScript) })
    };

    public override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsGood => true;
}
