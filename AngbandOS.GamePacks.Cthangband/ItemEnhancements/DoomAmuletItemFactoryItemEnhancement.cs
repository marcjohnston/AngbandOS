namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoomAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Cha => true; // TODO: The bonus value is controlled by a script
    public override bool Con => true; // TODO: The bonus value is controlled by a script
    public override bool IsCursed => true;
    public override bool Dex => true; // TODO: The bonus value is controlled by a script
    public override bool HideType => true;
    public override bool Int => true; // TODO: The bonus value is controlled by a script
    public override bool Str => true; // TODO: The bonus value is controlled by a script
    public override bool Wis => true; // TODO: The bonus value is controlled by a script
    public override int Weight => 3;
}