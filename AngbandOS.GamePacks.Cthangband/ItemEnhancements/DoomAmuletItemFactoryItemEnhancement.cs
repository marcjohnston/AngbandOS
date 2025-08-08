namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoomAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override int Weight => 3;
}