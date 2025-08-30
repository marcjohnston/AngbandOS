// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoeRingItemFactory : ItemFactoryGameConfiguration
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override bool Valueless => true;
    public override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override string Name => "Woe";
    public override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    public override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(SystemScriptsEnum.BrokenAndCursedEnchantmentScript), nameof(SystemScriptsEnum.PoorCharismaAndWisdom5BP1EnchantmentScript), nameof(SystemScriptsEnum.PoorArmorClass10BP5EnchantmentScript) })
    };
    public override string? ItemEnhancementBindingKey => nameof(WoeRingItemFactoryItemEnhancement);
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string ItemClassBindingKey => nameof(RingsItemClass);

    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.RightHandWieldSlot), nameof(WieldSlotsEnum.LeftHandWieldSlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
