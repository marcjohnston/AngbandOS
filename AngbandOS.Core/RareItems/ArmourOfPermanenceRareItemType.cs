namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmourOfPermanenceRareItem : RareItem
{
    private ArmourOfPermanenceRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Permanence";
    public override int Cost => 30000;
    public override string FriendlyName => "of Permanence";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 10;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourOfPermanence;
    public override int Rarity => 0;
    public override int Rating => 30;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override int Slot => 30;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
}
