namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class IronCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override int Weight => 20;
    public override int Cost => 500;
    public override int DamageDice => 1;
}
