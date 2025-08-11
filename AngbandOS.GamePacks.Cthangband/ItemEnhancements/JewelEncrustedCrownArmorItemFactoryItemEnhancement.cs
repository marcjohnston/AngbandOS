namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class JewelEncrustedCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override int Weight => 40;
    public override int Cost => 2000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
