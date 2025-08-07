namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MetalScaleMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 250;
    public override int Cost => 550;
}
