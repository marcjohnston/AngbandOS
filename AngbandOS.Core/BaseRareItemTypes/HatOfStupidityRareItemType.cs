using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfStupidityRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Stupidity";
    public override int Cost => 0;
    public override string FriendlyName => "of Stupidity";
    public override bool Int => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfStupidity;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
}
