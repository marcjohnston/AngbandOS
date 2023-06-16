// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.Realms;

[Serializable]
internal class FolkRealm : BaseRealm
{
    private FolkRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Folk realm is the least specialised of all the realms.",
        "Folk magic is capable of doing any effect that is possible", 
        "in other realms - but usually less effectively than the", 
        "specialist realms."
    };

    /// <summary>
    /// Returns the Cantrips for Beginners, Minor Magicks, Major Magicks and Magicks of Mastery books because they belong to the Folk realm.
    /// </summary>
    public override BookItemFactory[] SpellBooks => new BookItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<CantripsforBeginnersFolkBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<MinorMagicksFolkBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<MajorMagicksFolkBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<MagicksOfMasteryFolkBookItemFactory>()
    };

    public override string Name => "Folk";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.FolkBook;
}
