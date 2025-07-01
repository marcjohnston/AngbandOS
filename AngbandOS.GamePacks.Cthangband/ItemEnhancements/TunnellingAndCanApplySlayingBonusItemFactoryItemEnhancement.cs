namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TunnellingAndCanApplySlayingBonusItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
}