namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlowDigestionAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SlowDigest => true;
    public override int? Weight => 3;
    public override int? Value => 200;
}
