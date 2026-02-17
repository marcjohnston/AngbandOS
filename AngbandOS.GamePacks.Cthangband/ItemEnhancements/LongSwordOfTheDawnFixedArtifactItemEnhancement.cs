namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfTheDawnFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.SummonFriendlyReaverEvery500p1d500Activation);
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "20"),
        (nameof(MeleeToHitAttribute), "20"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "250000"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Dawn";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResBlind => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
    public override bool? SustCha => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
