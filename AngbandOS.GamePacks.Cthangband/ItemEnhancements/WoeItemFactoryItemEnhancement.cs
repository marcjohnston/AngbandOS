namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoeItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Cha => true;
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override bool Teleport => true;
    public override bool Wis => true;
}