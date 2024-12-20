// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

[Serializable]
internal class EllisTheFoolShopkeeper : Shopkeeper
{
    private EllisTheFoolShopkeeper(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Ellis the Fool";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    protected override string? RaceName => nameof(HumanRace);
}