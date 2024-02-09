// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class HorrificDescriptionsRepository : StringListRepository
{
    public HorrificDescriptionsRepository(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns HorrificDescriptions as the name of this string list repository.
    /// </summary>
    public override string Name => "HorrificDescriptions";

    public override void Load()
    {
        if (SaveGame.Configuration.HorrificDescriptions == null)
        {
            Add("abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
                "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
                "sacrilegious", "terrible", "unclean", "unspeakable");
        }
        else
        {
            Add(SaveGame.Configuration.HorrificDescriptions);
        }
    }
}