using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ShieldOfResistColdRareItemType : Base2RareItemType
{
    public override char Character => ')';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Shield of Resist Cold";
    public override int Cost => 600;
    public override string FriendlyName => "of Resist Cold";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.ShieldOfResistCold;
    public override int Rarity => 0;
    public override int Rating => 12;
    public override bool ResCold => true;
    public override int Slot => 32;
}
