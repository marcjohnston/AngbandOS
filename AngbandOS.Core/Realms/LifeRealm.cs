namespace AngbandOS.Core.Realms;

[Serializable]
internal class LifeRealm : BaseRealm
{
    private LifeRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Life realm is devoted to healing and buffing, with some", 
        "offensive capability against undead and demons. It is the", 
        "most defensive of the realms."
    };


    /// <summary>
    /// Returns the Common Prayers, High Mass, Dhol Chants and Ponape Scripture books because they belong to the Life realm.
    /// </summary>
    public override BookItemFactory[] SpellBooks => new BookItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<CommonPrayerLifeBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<HighMassLifeBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<DholChantsLifeBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<PonapeScriptureLifeBookItemFactory>()
    };
    public override string Name => "Life";

    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.LifeBook;

    public override bool SusceptibleToHolyAndHellProjectiles => true;
}
