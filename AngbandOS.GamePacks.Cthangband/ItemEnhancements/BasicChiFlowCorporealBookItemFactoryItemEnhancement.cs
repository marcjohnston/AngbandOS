namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BasicChiFlowCorporealBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 30;
    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
