namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Chaotic => true;
    public override bool ResChaos => true;
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
}