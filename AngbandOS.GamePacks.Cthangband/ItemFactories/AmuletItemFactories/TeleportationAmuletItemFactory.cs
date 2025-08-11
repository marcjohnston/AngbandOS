// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationAmuletItemFactory : ItemFactoryGameConfiguration
{
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;
    public override string SymbolBindingKey => nameof(DoubleQuoteSymbol);
    public override string Name => "Teleportation";
    public override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    public override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    public override string? ItemEnhancementBindingKey => nameof(TeleportationAmuletItemFactoryItemEnhancement);
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
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
}
