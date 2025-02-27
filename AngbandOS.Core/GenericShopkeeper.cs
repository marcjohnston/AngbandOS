// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericShopkeeper : Shopkeeper
{
    public GenericShopkeeper(Game game, ShopkeeperGameConfiguration shopkeeperGameConfiguration) : base(game)
    {
        Key = shopkeeperGameConfiguration.Key ?? shopkeeperGameConfiguration.GetType().Name;
        MaxCost = shopkeeperGameConfiguration.MaxCost;
        MinInflate = shopkeeperGameConfiguration.MinInflate;
        Name = shopkeeperGameConfiguration.Name;
        RaceName = shopkeeperGameConfiguration.RaceName;
    }

    public override string Key { get; }

    public override int MaxCost { get; }

    public override int MinInflate { get; }

    public override string Name { get; }

    protected override string? RaceName { get; }
}
