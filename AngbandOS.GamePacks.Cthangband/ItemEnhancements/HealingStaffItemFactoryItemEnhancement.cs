namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HealingStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Value => 5000;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
