namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PintOfFineAleFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override int? Value => 1;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
