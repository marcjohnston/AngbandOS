namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldenCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override int Weight => 30;
    public override int Value => 1000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Gold;
}
