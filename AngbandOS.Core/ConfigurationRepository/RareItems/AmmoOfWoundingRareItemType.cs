// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class AmmoOfWoundingRareItem : RareItem
{
    private AmmoOfWoundingRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBracketSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Ammo of Wounding";
    public override int Cost => 20;
    public override string FriendlyName => "of Wounding";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfWounding;
    public override int Rarity => 0;
    public override int Rating => 5;
    public override int Slot => 23;
}