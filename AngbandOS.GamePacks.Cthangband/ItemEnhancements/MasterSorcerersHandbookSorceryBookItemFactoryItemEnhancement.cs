namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MasterSorcerersHandbookSorceryBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 30;
    public override int? Value => 1000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? HatesFire => "true";
}
