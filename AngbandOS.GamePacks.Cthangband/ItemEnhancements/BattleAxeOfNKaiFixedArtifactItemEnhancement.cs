namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeOfNKaiFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(StealthAttribute), "3"),
        (nameof(ValueAttribute), "90000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(AttacksAttribute), "5"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of N'Kai";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResAcid => true;
    public override bool? ResBlind => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
