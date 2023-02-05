namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class CloakOfEnvelopingRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Enveloping";
    public override int Cost => 0;
    public override string FriendlyName => "of Enveloping";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 10;
    public override int MaxToH => 10;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfEnveloping;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool ShowMods => true;
    public override int Slot => 31;
}
