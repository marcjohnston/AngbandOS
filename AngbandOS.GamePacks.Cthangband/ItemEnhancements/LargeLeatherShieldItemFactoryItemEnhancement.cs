namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeLeatherShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 100;
    public override int Value => 120;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
