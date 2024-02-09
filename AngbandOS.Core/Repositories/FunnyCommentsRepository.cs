// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class FunnyCommentsRepository : StringListRepository
{
    public FunnyCommentsRepository(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns FunnyComments as the name of this string list repository.
    /// </summary>
    public override string Name => "FunnyComments";

    public override void Load()
    {
        if (SaveGame.Configuration.FunnyComments == null)
        {
            Add("Wow, cosmic, man!",
                "Rad!",
                "Groovy!",
                "Cool!",
                "Far out!"
                );
        }
        else
        {
            Add(SaveGame.Configuration.FunnyComments);
        }
    }
}