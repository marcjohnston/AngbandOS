// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class CloakOfAmanRareItem : RareItem
{
    private CloakOfAmanRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Aman";
    public override int Cost => 4000;
    public override string FriendlyName => "of Aman";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 20;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfAman;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 31;
    public override bool Stealth => true;
}
