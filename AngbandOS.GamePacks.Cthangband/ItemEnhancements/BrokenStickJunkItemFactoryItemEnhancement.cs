namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrokenStickJunkItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 3;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? HatesAcid => "true";
    public override bool? Valueless => true;
}
