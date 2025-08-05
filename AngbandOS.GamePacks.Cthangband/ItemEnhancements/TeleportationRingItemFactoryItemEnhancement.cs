namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool EasyKnow => true;
    public override bool Teleport => true;
    public override int Weight => 2;
}
[Serializable]
public class TeleportationAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool EasyKnow => true;
    public override bool Teleport => true;
    public override int Weight => 3;
}