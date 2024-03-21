// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class NatureRealm : Realm
{
    private NatureRealm(Game savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Nature realm has a large number of summoning spells and",
        "miscellaneous spells, but little in the way of offensive", 
        "and defensive capabilities."
    };


    /// <summary>
    /// Returns the Call of the Wild, Nature Mastery, Revelations of Glaaki and Cthaat Aquadingen books because they belong to the Nature realm.
    /// </summary>
    protected override string[] SpellBookNames => new string[]
    {
        nameof(CallOfTheWildNatureBookItemFactory),
        nameof(NatureMasteryNatureBookItemFactory),
        nameof(RevelationsOfGlaakiNatureBookItemFactory),
        nameof(CthaatAquadingenNatureBookItemFactory)
    };
    public override string Name => "Nature";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.NatureBook;
}
