namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HumanSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 60;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
