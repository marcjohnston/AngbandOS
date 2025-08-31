namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShardOfPotteryJunkItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? HatesAcid => "true";
    public override bool? Valueless => true;
}
