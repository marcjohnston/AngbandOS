using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponVampiricRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Vampiric)";
    public override int Cost => 10000;
    public override string FriendlyName => "(Vampiric)";
    public override bool HoldLife => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponVampiric;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override int Slot => 24;
    public override bool Vampiric => true;
}
