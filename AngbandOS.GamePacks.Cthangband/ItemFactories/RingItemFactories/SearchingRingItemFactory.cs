// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SearchingRingItemFactory : ItemFactoryGameConfiguration
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;
    public override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override string Name => "Searching";
    public override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    public override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(SystemScriptsEnum.BrokenAndCursedEnchantmentScript), nameof(SystemScriptsEnum.PoorSearch5BP1EnchantmentScript) }),
        (new int[] {0, 1, 2}, null, new string[] { nameof(SystemScriptsEnum.BonusSearch5BP1EnchantmentScript) })
    };

    public override int Cost => 250;
    public override string? ItemEnhancementBindingKey => nameof(SearchingItemFactoryItemEnhancement);
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 2;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string ItemClassBindingKey => nameof(RingsItemClass);

    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.RightHandWieldSlot), nameof(WieldSlotsEnum.LeftHandWieldSlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
