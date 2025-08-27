namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallLeatherShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 50;
    public override int Value => 30;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
