namespace AngbandOS.Core.Realms;

[Serializable]
internal class DeathRealm : BaseRealm
{
    private DeathRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Death realm has a combination of life-draining spells,",
        "curses, and undead summoning. Like chaos, it is a very",
        "offensive realm."
    };
    public override string Name => "Death";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.DeathBook;

    /// <summary>
    /// Returns the Black Prayers, Black Mass, Cultesdes Goules and Necronomicon books because they belong to the Death realm.
    /// </summary>
    public override BookItemFactory[] SpellBooks => new BookItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<BlackPrayersDeathBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<BlackMassDeathBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<CultesdesGoulesDeathBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<NecronomiconDeathBookItemFactory>()
    };
    public override bool ResistantToHolyAndHellProjectiles => true;
}
