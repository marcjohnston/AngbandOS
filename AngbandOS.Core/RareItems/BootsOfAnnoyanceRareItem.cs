// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BootsOfAnnoyanceRareItem : RareItem
{
    private BootsOfAnnoyanceRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Annoyance";
    public override int BonusSpeed => 10;
    public override int TreasureRating => 0;
    public override bool Speed => true;
}
