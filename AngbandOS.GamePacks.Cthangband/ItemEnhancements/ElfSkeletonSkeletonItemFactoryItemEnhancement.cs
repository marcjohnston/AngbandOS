namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ElfSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 40;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
