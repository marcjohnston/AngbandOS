namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HolinessStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Cost => 4500;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
    public override ColorEnum Color => ColorEnum.Purple;
}
