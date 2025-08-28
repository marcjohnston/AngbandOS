// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponPlanarWeaponItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    public override string? ActivationName => nameof(ActivationsEnum.Teleport100Every1d50p50Activation);
    public override int? Value => 7000;
    public override bool? FreeAct => true;
    public override string? FriendlyName => "(Planar Weapon)";
    public override string? BonusSearchRollExpression => "1d2";
    public override string? BonusDamageRollExpression => "1d4";
    public override string? BonusHitsRollExpression => "1d4";
    public override int? TreasureRating => 22;
    public override bool? Regen => true;
    public override bool? ResNexus => true;
    public override bool? SlayEvil => true;
    public override bool? SlowDigest => true;
    public override bool? Teleport => true;
}
