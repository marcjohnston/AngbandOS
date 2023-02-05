namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfAnimalBaneRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Animal Bane";
    public override int Cost => 6000;
    public override string FriendlyName => "of Animal Bane";
    public override bool Int => true;
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfAnimalBane;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool Regen => true;
    public override bool SlayAnimal => true;
    public override int Slot => 24;
}
