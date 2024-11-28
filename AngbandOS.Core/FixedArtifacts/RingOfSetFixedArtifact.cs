// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfSetFixedArtifact : FixedArtifact
{
    private RingOfSetFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(PowerRingItemFactory);

    protected override string? ActivationName => nameof(BizarreThingsEvery1d450p450Activation);
    public override void ApplyResistances(Item item)
    {
        item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();

        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Ring of Set";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 5000000;
    public override int TreasureRating => 20;
    public override bool IsCursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override bool DrainExp => true;
    public override bool DreadCurse => true;
    public override int Ds => 1;
    public override string FriendlyName => "of Set";
    public override bool HasOwnType => true;
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override bool ImCold => true;
    public override bool ImElec => true;
    public override bool ImFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 100;
    public override bool PermaCurse => true;
    protected override string? BonusCharismaRollExpression => "5";
    protected override string? BonusConstitutionRollExpression => "5";
    protected override string? BonusDexterityRollExpression => "5";
    protected override string? BonusIntelligenceRollExpression => "5";
    protected override string? BonusSpeedRollExpression => "5";
    protected override string? BonusStrengthRollExpression => "5";
    protected override string? BonusWisdomRollExpression => "5";
    public override int Rarity => 100;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 15;
    public override int Weight => 2;
    public override bool Wis => true;
}
