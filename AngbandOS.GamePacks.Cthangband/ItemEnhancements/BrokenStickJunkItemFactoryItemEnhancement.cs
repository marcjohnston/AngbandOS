namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class BrokenStickJunkItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 3;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
