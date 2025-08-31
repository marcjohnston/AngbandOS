namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GnomeSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 30;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override ColorEnum? Color => ColorEnum.Beige;
    public override string? HatesAcid => "true";
    public override bool? Valueless => true;
}
