namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MithrilPlateMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 300;
}