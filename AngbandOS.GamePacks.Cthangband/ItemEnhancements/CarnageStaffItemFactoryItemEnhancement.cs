namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CarnageStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Cost => 3500;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
