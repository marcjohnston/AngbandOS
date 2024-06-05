// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class AmmoOfShockingRareItem : RareItem
{
    private AmmoOfShockingRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool BrandElec => true;
    public override int Cost => 30;
    public override string FriendlyName => "of Shocking";
    public override bool IgnoreElec => true;
    public override int TreasureRating => 10;
    }
