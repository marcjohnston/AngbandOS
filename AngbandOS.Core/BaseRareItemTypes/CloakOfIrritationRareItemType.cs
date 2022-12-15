using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CloakOfIrritationRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Irritation";
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Irritation";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 15;
    public override int MaxToH => 15;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.CloakOfIrritation;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool ShowMods => true;
    public override int Slot => 31;
}
