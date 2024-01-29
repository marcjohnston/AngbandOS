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
    public GoldItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(GoldItemClass));
    public override int PackSort => 0;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;

    /// <summary>
    /// Returns the value of the gold, which is assigned to the type specific value.  The value of the gold defaults to 8dCost+1d8;
    /// </summary>
    public override int InitialTypeSpecificValue => Cost + (8 * SaveGame.Rng.DieRoll(Cost)) + SaveGame.Rng.DieRoll(8);
    public override bool IsIgnoredByMonsters => true;
}
