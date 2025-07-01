namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool InstaArt => true;
    public override bool CanApplySlayingBonus => true;
}