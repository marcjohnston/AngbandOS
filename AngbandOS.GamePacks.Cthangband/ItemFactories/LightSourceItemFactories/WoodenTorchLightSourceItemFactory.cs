// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoodenTorchLightSourceItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns true because a torch can be used as fuel for another torch.
    /// </summary>
    public override bool IsFuelForTorch => true;

    /// <summary>
    /// Returns 1 because wooden torches consume a single turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override string Name => "Wooden Torch";

    /// <summary>
    /// Returns 5000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 5000;

    public override string? DescriptionSyntax => "Wooden Torch~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int InitialTurnsOfLight => 4000;
    public override string? RefillScriptBindingKey => nameof(SystemScriptsEnum.RefillLightSourceFromTorchScript);
    public override string? ItemEnhancementBindingKey => nameof(WoodenTorchLightSourceItemFactoryItemEnhancement);

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
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatOrbOfLightEnchantmentScript) }),
         (null, true, new string[] { nameof(SystemScriptsEnum.FillTorchEnchantmentScript) }),
        (null, false, new string[] { nameof(SystemScriptsEnum.UsedTorchEnchantmentScript) })
    };

    public override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
