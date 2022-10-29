using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfSeeingRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Seeing";
    public override int Cost => 1000;
    public override string FriendlyName => "of Seeing";
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfSeeing;
    public override int Rarity => 0;
    public override int Rating => 8;
    public override bool ResBlind => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override int Slot => 33;
}
