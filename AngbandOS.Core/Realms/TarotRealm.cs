namespace AngbandOS.Core.Realms;

[Serializable]
internal class TarotRealm : BaseRealm
{
    private TarotRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Tarot realm is one of the most specialised realms of", 
        "all, almost exclusively containing summoning and transport", 
        "spells."
   };
    public override string Name => "Tarot";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.TarotBook;

    /// <summary>
    /// Returns the Conjurings Tricks, Card Mastery, Eltdown Shards and Celeano Fragments books because they belong to the Tarot realm.
    /// </summary>
    public override BookItemFactory[] SpellBooks => new BookItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<ConjuringsTricksTarotBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<CardMasteryTarotBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<EltdownShardsTarotBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<CeleanoFragmentsTarotBookItemFactory>()
    };
}
