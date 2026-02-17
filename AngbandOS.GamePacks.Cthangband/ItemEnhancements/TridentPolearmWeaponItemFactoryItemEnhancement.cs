namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentPolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "70"),
        (nameof(ValueAttribute), "120"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "8"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
