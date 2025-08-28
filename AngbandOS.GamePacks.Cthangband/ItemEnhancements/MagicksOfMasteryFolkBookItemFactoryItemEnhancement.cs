namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagicksOfMasteryFolkBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 30;
    public override int? Value => 2500;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightPurple;
}
