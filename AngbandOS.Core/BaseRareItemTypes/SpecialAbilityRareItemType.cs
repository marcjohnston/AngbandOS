using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SpecialAbilityRareItemType : Base2RareItemType
{
    public override char Character => 'x';
    public override string Name => "Special Ability";
    public override int Cost => 0;
    public override string FriendlyName => "";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.SpecialAbility;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 0;
}
