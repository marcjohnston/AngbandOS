namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlingRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlowsBonus => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Brown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
