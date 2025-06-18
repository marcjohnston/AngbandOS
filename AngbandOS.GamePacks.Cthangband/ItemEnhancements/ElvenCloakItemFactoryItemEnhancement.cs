namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElvenCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Search => true;
    public override bool Stealth => true;
}