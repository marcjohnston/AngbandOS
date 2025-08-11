namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeIronChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 1000;
    public override int Cost => 150;
    public override int DamageDice => 2;
    public override int DiceSides => 6;
}
