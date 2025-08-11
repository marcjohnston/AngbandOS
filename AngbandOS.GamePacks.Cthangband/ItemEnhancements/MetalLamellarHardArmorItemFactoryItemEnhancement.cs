namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalLamellarHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 340;
    public override int Cost => 1250;
    public override int DamageDice => 1;
    public override int DiceSides => 6;
}
