namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BallAndChainHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "150"),
        (nameof(ValueAttribute), "200"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
