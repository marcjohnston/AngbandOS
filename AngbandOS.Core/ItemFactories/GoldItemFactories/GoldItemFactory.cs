// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class GoldItemFactory : ItemFactory
{
    public GoldItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(GoldItemClass));
    public override int PackSort => 0;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;

    /// <summary>
    /// Returns value that is used to compute (8dGoldValue+1d8+GoldValue) a random value that is assigned when gold is created.
    /// </summary>
    public abstract int GoldValue { get; }

    /// <summary>
    /// Returns the value of the gold, which is assigned to the type specific value.  The value of the gold defaults to 8dCost+1d8 + Cost;
    /// </summary>
    public override int InitialGoldPieces => GoldValue + (8 * Game.DieRoll(GoldValue)) + Game.DieRoll(8);
    public override bool IsIgnoredByMonsters => true;
}
