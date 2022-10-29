using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class CloakOfStealthRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Stealth";
    public override int Cost => 500;
    public override string FriendlyName => "of Stealth";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.CloakOfStealth;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 31;
    public override bool Stealth => true;
}
