namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CanineSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 10;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
