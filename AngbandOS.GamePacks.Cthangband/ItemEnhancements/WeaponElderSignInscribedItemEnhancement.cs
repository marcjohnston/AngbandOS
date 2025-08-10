// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponElderSignInscribedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(SustainItemEnhancementWeightedRandom);
    public override bool Blessed => true;
    public override int Value => 20000;
    public override string? FriendlyName => "(Elder Sign Inscribed)";
    public override string? BonusWisdomRollExpression => "1d4";
    public override string? BonusArmorClassRollExpression => "1d4";
    public override string? BonusDamageRollExpression => "1d6";
    public override string? BonusHitsRollExpression => "1d6";
    public override int TreasureRating => 30;
    public override bool ResFear => true;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
}
