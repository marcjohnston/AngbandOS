namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FullPlateHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 380;
    public override int Cost => 1350;
}
