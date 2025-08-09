namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BarChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 280;
    public override int Cost => 950;
    public override int DamageDice => 1;
}
