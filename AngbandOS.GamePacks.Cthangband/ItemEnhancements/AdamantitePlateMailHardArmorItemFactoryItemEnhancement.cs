namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class AdamantitePlateMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 420;
    public override int Cost => 20000;
    public override int DamageDice => 2;
    public override int DiceSides => 4;
}
