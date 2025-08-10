namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class EmptyBottleItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 2;
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
