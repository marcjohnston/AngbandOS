namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MetalBrigandineHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 290;
    public override int Cost => 1100;
    public override int DamageDice => 1;
    public override int DiceSides => 4;
}
