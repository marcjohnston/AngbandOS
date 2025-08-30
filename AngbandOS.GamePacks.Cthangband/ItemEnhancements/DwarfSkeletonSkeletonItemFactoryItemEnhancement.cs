namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarfSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 50;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override ColorEnum? Color => ColorEnum.Beige;
    public override string? HatesAcid => "true";
}
