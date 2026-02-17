namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "75"),
        (nameof(ValueAttribute), "48"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
