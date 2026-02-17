namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeekerArrowAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "20"),
        (nameof(DamageDiceAttribute), "4"),
        (nameof(DiceSidesAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

