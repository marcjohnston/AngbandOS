namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDistruptionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
}