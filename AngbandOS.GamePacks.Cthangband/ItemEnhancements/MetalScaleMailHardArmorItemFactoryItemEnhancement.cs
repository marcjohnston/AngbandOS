namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalScaleMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 250;
    public override int Cost => 550;
    public override int DamageDice => 1;
    public override int DiceSides => 4;
}
