// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class GlovesOfPowerRareItem : RareItem
{
    private GlovesOfPowerRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Gloves of Power";
    public override int Cost => 2500;
    public override string FriendlyName => "of Power";
    public override bool HideType => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.GlovesOfPower;
    public override int Rarity => 0;
    public override int Rating => 22;
    public override bool ShowMods => true;
    public override int Slot => 34;
    public override bool Str => true;
}