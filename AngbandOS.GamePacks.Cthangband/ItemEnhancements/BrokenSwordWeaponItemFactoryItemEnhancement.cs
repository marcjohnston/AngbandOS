namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrokenSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "2"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(ToDamageAttribute), "-4"),
        (nameof(DiceSidesAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
}
