namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightningBallsWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreElec => true;
    public override int Weight => 10;
    public override int Value => 1200;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Chartreuse;
}
