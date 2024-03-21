// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class DardobardTheWeakShopkeeper : Shopkeeper
{
    private DardobardTheWeakShopkeeper(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Dardobard the Weak";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    protected override string? RaceName => nameof(SpectreRace);
}