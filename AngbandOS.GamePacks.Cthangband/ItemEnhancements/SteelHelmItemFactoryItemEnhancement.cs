namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 60;
    public override int? Value => 200;
    public override int? DamageDice => 1;
    public override int? DiceSides => 3;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? BaseArmorClass => "6";
}
