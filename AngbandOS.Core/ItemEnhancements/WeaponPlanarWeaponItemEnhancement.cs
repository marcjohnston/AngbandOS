// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�


namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponPlanarWeaponItemEnhancement : ItemEnhancement
{
    private WeaponPlanarWeaponItemEnhancement(Game game) : base(game) { } // This object is a singleton.

    protected override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    protected override string? ActivationName => nameof(Teleport100Every1d50p50Activation);
    public override int? Value => 7000;
    public override bool FreeAct => true;
    public override string? FriendlyName => "(Planar Weapon)";
    protected override string? BonusSearchRollExpression => "1d2";
    protected override string? BonusDamageRollExpression => "1d4";
    protected override string? BonusHitRollExpression => "1d4";
    public override int TreasureRating => 22;
    public override bool Regen => true;
    public override bool ResNexus => true;
    public override bool Search => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Teleport => true;
}
