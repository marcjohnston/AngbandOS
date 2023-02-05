namespace AngbandOS.Core;

[Serializable]
internal class ShieldOfReflectionRareItemType : Base2RareItemType
{
    public override char Character => ')';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Shield of Reflection";
    public override int Cost => 15000;
    public override string FriendlyName => "of Reflection";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 5;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.ShieldOfReflection;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool Reflect => true;
    public override int Slot => 32;
}
