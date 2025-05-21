// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TarotRealm : RealmGameConfiguration
{
    public override string[] Info => new string[] {
        "The Tarot realm is one of the most specialised realms of", 
        "all, almost exclusively containing summoning and transport", 
        "spells."
   };
    public override string Name => "Tarot";

    /// <summary>
    /// Returns the Conjurings Tricks, Card Mastery, Eltdown Shards and Celeano Fragments books because they belong to the Tarot realm.
    /// </summary>
    public override string[] SpellBookNames => new string[]
    {
        nameof(ConjuringsTricksTarotBookItemFactory),
        nameof(CardMasteryTarotBookItemFactory),
        nameof(EltdownShardsTarotBookItemFactory),
        nameof(CeleanoFragmentsTarotBookItemFactory)
    };
}
