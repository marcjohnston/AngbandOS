namespace AngbandOS.Core;

[Serializable]
internal class WeaponElderSignInscribedRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Elder Sign Inscribed)";
    public override bool Blessed => true;
    public override int Cost => 20000;
    public override string FriendlyName => "(Elder Sign Inscribed)";
    public override int Level => 0;
    public override int MaxPval => 4;
    public override int MaxToA => 4;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.WeaponElderSign;
    public override int Rarity => 0;
    public override int Rating => 30;
    public override bool ResFear => true;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int Slot => 24;
    public override bool Wis => true;
}
