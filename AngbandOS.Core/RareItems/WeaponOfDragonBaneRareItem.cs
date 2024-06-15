// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfDragonBaneRareItem : RareItem
{
    private WeaponOfDragonBaneRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Con => true;
    public override int Cost => 6000;
    public override string FriendlyName => "of Dragon Bane";
    public override bool KillDragon => true;
    public override int BonusConstitution => 1;
    public override int TreasureRating => 24;
    public override bool SlayDragon => true;
}
