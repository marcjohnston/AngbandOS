using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HatOfRegenerationRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Regeneration";
    public override int Cost => 1500;
    public override string FriendlyName => "of Regeneration";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.HatOfRegeneration;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool Regen => true;
    public override int Slot => 33;
}
