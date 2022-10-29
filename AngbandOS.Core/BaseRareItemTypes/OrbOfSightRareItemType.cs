using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class OrbOfSightRareItemType : Base2RareItemType
{
    public override char Character => '~';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Orb of Sight";
    public override int Cost => 1000;
    public override string FriendlyName => "of Sight";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.OrbOfSight;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool ResBlind => true;
    public override int Slot => 0;
}
