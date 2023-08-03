// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class WorshipPlayerAttacksRepositoryCollection : ListRepositoryCollection<string>
{
    public WorshipPlayerAttacksRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        Add("looks up at you!", 
            "asks how many dragons you've killed!", 
            "asks for your autograph!", 
            "tries to shake your hand!", 
            "pretends to be you!",
            "dances around you!", 
            "tugs at your clothing!", 
            "asks if you will adopt him!"
            );
    }
}