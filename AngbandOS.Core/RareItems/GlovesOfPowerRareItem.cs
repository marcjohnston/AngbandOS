// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class GlovesOfPowerRareItem : RareItem
{
    private GlovesOfPowerRareItem(Game game) : base(game) { } // This object is a singleton.
    public override int Cost => 2500;
    public override string? FriendlyName => "of Power";
    public override bool HideType => true;
    protected override string? BonusStrengthRollExpression => "1d5";
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override int TreasureRating => 22;
    public override bool ShowMods => true;
    public override bool Str => true;
}
