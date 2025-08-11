namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 20;
    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.Black;
}
