// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class LifeRealm : Realm
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
        (BookItemFactory)SaveGame.SingletonRepository.ItemFactories.Get(nameof(CommonPrayerLifeBookItemFactory)),
        (BookItemFactory)SaveGame.SingletonRepository.ItemFactories.Get(nameof(HighMassLifeBookItemFactory)),
        (BookItemFactory)SaveGame.SingletonRepository.ItemFactories.Get(nameof(DholChantsLifeBookItemFactory)),
        (BookItemFactory)SaveGame.SingletonRepository.ItemFactories.Get(nameof(PonapeScriptureLifeBookItemFactory))
    };
    public override string Name => "Life";

    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.LifeBook;

    public override bool SusceptibleToHolyAndHellProjectiles => true;
}
