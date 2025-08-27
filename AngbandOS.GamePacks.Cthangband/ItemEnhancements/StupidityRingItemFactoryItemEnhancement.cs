namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StupidityRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override int Weight => 2;
    public override int Value => -5000;
}
