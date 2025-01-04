// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class FindQuestsRepository : StringsRepository
{
    public FindQuestsRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns FindQuests as the name of this string list repository.
    /// </summary>
    public override string Name => "FindQuests";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.FindQuests == null)
        {
            Add("You find the following inscription in the floor",
                "You see a message inscribed in the wall",
                "There is a sign saying",
                "Something is written on the staircase",
                "You find a scroll with the following message"
                );
        }
        else
        {
            Add(configuration.FindQuests);
        }
    }
}