namespace AngbandOS.Core;

[Serializable]
internal class ArmourOfYithRareItemType : Base2RareItemType
{
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Yith";
    public override int Cost => 15000;
    public override string FriendlyName => "of Yith";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 10;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.ArmourOfYith;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override int Slot => 30;
    public override bool Stealth => true;
}
