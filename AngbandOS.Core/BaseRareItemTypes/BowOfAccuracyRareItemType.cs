using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BowOfAccuracyRareItemType : Base2RareItemType
{
    public override char Character => '}';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Bow of Accuracy";
    public override int Cost => 1000;
    public override string FriendlyName => "of Accuracy";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 15;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.BowOfAccuracy;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 25;
}
