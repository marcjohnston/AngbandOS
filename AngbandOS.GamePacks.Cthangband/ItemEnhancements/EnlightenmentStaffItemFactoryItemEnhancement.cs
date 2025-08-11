namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EnlightenmentStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Cost => 750;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
    public override ColorEnum Color => ColorEnum.Purple;
}
