// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfMightRareItem : RareItem
{
    private HatOfMightRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Con => true;
    public override int Cost => 2000;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Might";
    protected override string? BonusStrengthRollExpression => "1d3";
    protected override string? BonusWisdomRollExpression => "1d3";
    public override int TreasureRating => 19;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
}
