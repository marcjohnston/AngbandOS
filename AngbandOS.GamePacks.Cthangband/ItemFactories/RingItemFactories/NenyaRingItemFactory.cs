// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NenyaRingItemFactory : ItemFactoryGameConfiguration
{
    public override string[]? EnhancementFixedArtifactFactoriesBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfElementalPowerIceFixedArtifact) };
    public override bool DisableStomp => true;
    public override bool NegativeBonusArmorClassRepresentsBroken => true;
    public override bool NegativeBonusHitRepresentsBroken => true;
    public override bool NegativeBonusDamageRepresentsBroken => true;
    public override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override string Name => "Nenya";
    public override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    public override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override string? ItemEnhancementBindingKey => nameof(NenyaRingItemFactoryItemEnhancement);
    public override int LevelNormallyFound => 90;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string ItemClassBindingKey => nameof(RingsItemClass);

    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.RightHandWieldSlot), nameof(WieldSlotsEnum.LeftHandWieldSlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool IsGood => true;
}
