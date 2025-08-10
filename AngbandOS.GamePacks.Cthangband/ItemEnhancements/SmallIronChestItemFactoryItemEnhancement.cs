namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SmallIronChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 300;
    public override int Cost => 100;
    public override int DamageDice => 2;
    public override int DiceSides => 4;
}
