// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WisdomAmuletItemFactory : ItemFactoryGameConfiguration
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;
    public override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(SystemScriptsEnum.BrokenAndCursedEnchantmentScript), nameof(SystemScriptsEnum.PoorWisdomEnchantmentScript) }),
        (new int[] {0, 1, 2}, null, new string[] { nameof(SystemScriptsEnum.BonusWisdomEnchantmentScript) })
    };
    public override string SymbolBindingKey => nameof(DoubleQuoteSymbol);
    public override string Name => "Wisdom";
    public override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    public override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    public override string? ItemEnhancementBindingKey => nameof(WisdomAmuletItemFactoryItemEnhancement);
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because amulets are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string ItemClassBindingKey => nameof(AmuletsItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.NeckWieldSlot) };
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override bool IsGood => true;
}
