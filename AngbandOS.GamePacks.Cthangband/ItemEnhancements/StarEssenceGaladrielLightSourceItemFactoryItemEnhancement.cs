namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceGaladrielLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Radius => 2;
    public override int Weight => 10;
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.Yellow;
}
