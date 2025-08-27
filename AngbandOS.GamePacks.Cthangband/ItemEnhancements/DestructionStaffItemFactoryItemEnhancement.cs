namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DestructionStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 50;
    public override int Value => 2500;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
