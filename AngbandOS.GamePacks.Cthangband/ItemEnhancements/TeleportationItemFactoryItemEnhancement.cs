namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool EasyKnow => true;
    public override bool Teleport => true;
}