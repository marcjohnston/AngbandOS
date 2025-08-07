namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CharismaAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Cha => true;
    public override bool HideType => true;
    public override int Weight => 3;
    public override int Cost => 500;
}
