// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GainMutationScript : Script, IScript
{
    private GainMutationScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.MutationsNotPossessed.Count == 0)
        {
            return;
        }
        Game.MsgPrint("You change...");
        int total = 0;
        foreach (Mutation mutation in Game.MutationsNotPossessed)
        {
            total += mutation.Frequency;
        }
        int roll = Game.DieRoll(total);
        for (int i = 0; i < Game.MutationsNotPossessed.Count; i++)
        {
            roll -= Game.MutationsNotPossessed[i].Frequency;
            if (roll > 0)
            {
                continue;
            }
            Mutation mutation = Game.MutationsNotPossessed[i];
            Game.MutationsNotPossessed.RemoveAt(i);
            if (Game.MutationsPossessed.Count > 0 && mutation.Group != MutationGroup.None)
            {
                int j = 0;
                do
                {
                    if (Game.MutationsPossessed[j].Group == mutation.Group)
                    {
                        Mutation other = Game.MutationsPossessed[j];
                        Game.MutationsPossessed.RemoveAt(j);
                        other.OnLose();
                        Game.MsgPrint(other.LoseMessage);
                        Game.MutationsNotPossessed.Add(other);
                    }
                    else
                    {
                        j++;
                    }
                } while (j < Game.MutationsPossessed.Count);
            }
            Game.MutationsPossessed.Add(mutation);
            mutation.OnGain();
            Game.MsgPrint(mutation.GainMessage);
            Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
            Game.HandleStuff();
            return;
        }
        Game.MsgPrint("Oops! Fell out of mutation list!");
    }
}
