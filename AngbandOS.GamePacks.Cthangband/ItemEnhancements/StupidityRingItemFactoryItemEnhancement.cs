namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StupidityRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override bool Int => true;
    public override int Weight => 2;
}