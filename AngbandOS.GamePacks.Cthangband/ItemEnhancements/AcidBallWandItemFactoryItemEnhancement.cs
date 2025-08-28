namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBallWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override int? Weight => 10;
    public override int? Value => 1650;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Chartreuse;
}
