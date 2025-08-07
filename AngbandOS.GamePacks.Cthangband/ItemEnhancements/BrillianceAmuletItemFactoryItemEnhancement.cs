namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrillianceAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override bool Int => true;
    public override bool Wis => true;
    public override int Weight => 3;
    public override int Cost => 500;
}
