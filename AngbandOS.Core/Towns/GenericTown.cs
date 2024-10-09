// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class GenericTown : Town
{
    public GenericTown(Game game, TownGameConfiguration townDefinition) : base(game)
    {
        Key = townDefinition.Key;
        DungeonName = townDefinition.DungeonName;
        HousePrice = townDefinition.HousePrice;
        Name = townDefinition.Name;
        Char = townDefinition.Char;
        StoreFactoryNames = townDefinition.StoreFactoryNames;
    }

    public override string DungeonName { get; }
    public override string Key { get; }
    public override int HousePrice { get; }
    public override string Name { get; }
    public override char Char { get; }
    protected override string[] StoreFactoryNames { get; }
}
