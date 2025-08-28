namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportOtherWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 10;
    public override int? Value => 350;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Chartreuse;
}
