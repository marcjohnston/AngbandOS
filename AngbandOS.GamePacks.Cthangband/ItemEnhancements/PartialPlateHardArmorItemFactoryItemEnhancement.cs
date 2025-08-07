namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class PartialPlateHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 260;
    public override int Cost => 1200;
}
