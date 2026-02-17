namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "1000"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(DiceSidesAttribute), "9"),
    };
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
