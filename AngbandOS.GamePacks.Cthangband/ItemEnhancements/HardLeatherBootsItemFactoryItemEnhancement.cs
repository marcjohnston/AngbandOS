namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherBootsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 40;
    public override int Cost => 12;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
