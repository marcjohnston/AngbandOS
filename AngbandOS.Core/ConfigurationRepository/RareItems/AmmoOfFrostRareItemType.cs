// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class AmmoOfFrostRareItem : RareItem
{
    private AmmoOfFrostRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBracketSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Ammo of Frost";
    public override bool BrandCold => true;
    public override int Cost => 25;
    public override string FriendlyName => "of Frost";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfFrost;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 23;
}