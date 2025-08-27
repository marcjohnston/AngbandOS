namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Value => 250;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
