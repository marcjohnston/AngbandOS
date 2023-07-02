// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BootsOfFreeActionRareItem : RareItem
{
    private BootsOfFreeActionRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots of Free Action";
    public override int Cost => 1000;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Free Action";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BootsOfFreeAction;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override int Slot => 35;
}
