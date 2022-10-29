using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfIntelligenceRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Intelligence";
    public override int Cost => 500;
    public override string FriendlyName => "of Intelligence";
    public override bool Int => true;
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfIntelligence;
    public override int Rarity => 0;
    public override int Rating => 13;
    public override int Slot => 33;
    public override bool SustInt => true;
}
