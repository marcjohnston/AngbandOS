namespace AngbandOS.Core;

[Serializable]
internal class HatOfUglinessRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Ugliness";
    public override bool Cha => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Ugliness";
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfUgliness;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
}
