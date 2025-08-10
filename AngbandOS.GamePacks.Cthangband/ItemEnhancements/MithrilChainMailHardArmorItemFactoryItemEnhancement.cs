namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MithrilChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 150;
    public override int Cost => 7000;
    public override int DamageDice => 1;
    public override int DiceSides => 4;
}
