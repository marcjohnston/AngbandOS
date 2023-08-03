// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class CloakOfImmolationRareItem : RareItem
{
    private CloakOfImmolationRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Cloak of Immolation";
    public override int Cost => 4000;
    public override string FriendlyName => "of Immolation";
    public override bool IgnoreAcid => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 4;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfImmolation;
    public override int Rarity => 0;
    public override int Rating => 16;
    public override bool ResFire => true;
    public override bool ShFire => true;
    public override int Slot => 31;
}
