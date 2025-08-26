namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CestiGlovesItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 40;
    public override int Value => 100;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
