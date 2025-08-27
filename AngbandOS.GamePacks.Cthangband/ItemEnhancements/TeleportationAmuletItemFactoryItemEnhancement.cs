namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool EasyKnow => true;
    public override bool Teleport => true;
    public override int Weight => 3;
    public override int Value => 250;
}
