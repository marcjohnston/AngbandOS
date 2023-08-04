// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

internal class WeightedRandomAction
{
    private readonly SaveGame SaveGame;
    private Dictionary<int, Action> values = new Dictionary<int, Action>();

    public WeightedRandomAction(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public void Add(int weight, Action value)
    {
        for (int i = 0; i < weight; i++)
        {
            values.Add(values.Count, value);
        }
    }
    public void Choose()
    {
        int choice = SaveGame.Rng.RandomLessThan(values.Count);
        values[choice]();
    }
}
