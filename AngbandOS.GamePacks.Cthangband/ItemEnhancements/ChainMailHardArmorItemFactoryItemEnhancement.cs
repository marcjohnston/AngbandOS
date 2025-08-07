namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 220;
    public override int Cost => 750;
}
