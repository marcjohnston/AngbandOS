// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class InsultPlayerAttacksRepository : StringListRepository
{
    public InsultPlayerAttacksRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns InsultPlayerAttacks as the name of this string list repository.
    /// </summary>
    public override string Name => "InsultPlayerAttacks";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.InsultPlayerAttacks == null)
        {
            Add("insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!",
                "dances around you!", "makes obscene gestures!", "moons you!");
        }
        else
        {
            Add(configuration.InsultPlayerAttacks);
        }
    }
}