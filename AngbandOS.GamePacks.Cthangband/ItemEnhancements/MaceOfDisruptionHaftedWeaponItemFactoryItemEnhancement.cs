namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? SlayUndead => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "400"),
        (nameof(ValueAttribute), "4300"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(DiceSidesAttribute), "8"),
    };
    public override ColorEnum? Color => ColorEnum.Purple;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
