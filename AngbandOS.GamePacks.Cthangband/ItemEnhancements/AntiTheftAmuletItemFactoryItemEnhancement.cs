namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AntiTheftAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool NoTele => true;
    public override bool AntiTheft => true;
    public override int Weight => 3;
    public override int Value => 1000;
    public override ColorEnum Color => ColorEnum.Orange;
}
