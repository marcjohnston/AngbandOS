// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class CloakOfStealthRareItem : RareItem
{
    private CloakOfStealthRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Cloak of Stealth";
    public override int Cost => 500;
    public override string FriendlyName => "of Stealth";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfStealth;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 31;
    public override bool Stealth => true;
}
