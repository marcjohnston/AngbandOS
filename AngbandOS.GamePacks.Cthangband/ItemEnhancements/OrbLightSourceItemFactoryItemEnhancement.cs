namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Radius => 2;
    public override int Weight => 50;
    public override int Value => 1000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.BrightYellow;
}
