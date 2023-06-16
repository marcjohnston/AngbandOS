// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponVampiricRareItem : RareItem
{
    private WeaponVampiricRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
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
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponVampiric;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override int Slot => 24;
    public override bool Vampiric => true;
}
