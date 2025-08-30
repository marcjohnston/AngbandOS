namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceElendilLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Radius => 2;
    public override int? Weight => 5;
    public override int? Value => 25000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Yellow;
    public override string? HatesFire => "true";
}
