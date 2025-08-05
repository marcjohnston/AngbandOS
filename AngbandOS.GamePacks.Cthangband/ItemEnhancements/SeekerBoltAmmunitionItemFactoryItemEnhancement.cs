namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeekerBoltAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 3;
}

