// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class BathricTheColdShopkeeper : Shopkeeper
{
    private BathricTheColdShopkeeper(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Bathric the Cold";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    protected override string? RaceName => nameof(VampireRace);
}