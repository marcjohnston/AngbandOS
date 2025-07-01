namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShowModsAndCanApplySlayingBonusItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
}
