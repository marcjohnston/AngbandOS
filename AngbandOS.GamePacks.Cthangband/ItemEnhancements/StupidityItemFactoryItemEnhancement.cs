namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StupidityItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override bool Int => true;
}