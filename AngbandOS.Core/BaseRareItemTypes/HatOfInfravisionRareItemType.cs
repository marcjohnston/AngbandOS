using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfInfravisionRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Infravision";
    public override int Cost => 500;
    public override string FriendlyName => "of Infravision";
    public override bool HideType => true;
    public override bool Infra => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfInfravision;
    public override int Rarity => 0;
    public override int Rating => 11;
    public override int Slot => 33;
}
