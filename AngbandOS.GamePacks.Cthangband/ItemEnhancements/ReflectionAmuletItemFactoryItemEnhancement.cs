namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ReflectionAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Reflect => true;
    public override int? Weight => 3;
    public override int? Value => 30000;
}
