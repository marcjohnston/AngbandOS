namespace AngbandOS.Core;

[Serializable]
internal class ShieldOfResistFireRareItemType : Base2RareItemType
{
    public override char Character => ')';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Shield of Resist Fire";
    public override int Cost => 800;
    public override string FriendlyName => "of Resist Fire";
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ShieldOfResistFire;
    public override int Rarity => 0;
    public override int Rating => 14;
    public override bool ResFire => true;
    public override int Slot => 32;
}
