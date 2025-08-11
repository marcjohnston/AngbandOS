namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeWoodenChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 500;
    public override int Cost => 60;
    public override int DamageDice => 2;
    public override int DiceSides => 5;
}
