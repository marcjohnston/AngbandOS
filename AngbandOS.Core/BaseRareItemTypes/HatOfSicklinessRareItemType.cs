using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfSicklinessRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Sickliness";
    public override bool Con => true;
    public override int Cost => 0;
    public override bool Dex => true;
    public override string FriendlyName => "of Sickliness";
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfSickliness;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
    public override bool Str => true;
}
