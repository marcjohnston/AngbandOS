namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 270;
    public override int Cost => 900;
}
