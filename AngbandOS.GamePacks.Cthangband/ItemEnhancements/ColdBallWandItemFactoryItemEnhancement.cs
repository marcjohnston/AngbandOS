namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdBallWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 10;
    public override int? Value => 1500;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Chartreuse;
    public override string? HatesElectricity => "true";
}
