namespace AngbandOS.Core.Realms;

[Serializable]
internal class NatureRealm : BaseRealm
{
    private NatureRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Nature realm has a large number of summoning spells and",
        "miscellaneous spells, but little in the way of offensive", 
        "and defensive capabilities."
    };


    /// <summary>
    /// Returns the Call of the Wild, Nature Mastery, Revelations of Glaaki and Cthaat Aquadingen books because they belong to the Nature realm.
    /// </summary>
    public override BookItemFactory[] SpellBooks => new BookItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<CallOfTheWildNatureBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<NatureMasteryNatureBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<RevelationsOfGlaakiNatureBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<CthaatAquadingenNatureBookItemFactory>()
    };
    public override string Name => "Nature";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.NatureBook;
}
