namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronShotAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 5;
    public override int Cost => 2;
    public override int DamageDice => 1;
}

