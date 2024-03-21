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
    private GainMutationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.MutationsNotPossessed.Count == 0)
        {
            return;
        }
        SaveGame.MsgPrint("You change...");
        int total = 0;
        foreach (Mutation mutation in SaveGame.MutationsNotPossessed)
        {
            total += mutation.Frequency;
        }
        int roll = SaveGame.DieRoll(total);
        for (int i = 0; i < SaveGame.MutationsNotPossessed.Count; i++)
        {
            roll -= SaveGame.MutationsNotPossessed[i].Frequency;
            if (roll > 0)
            {
                continue;
            }
            Mutation mutation = SaveGame.MutationsNotPossessed[i];
            SaveGame.MutationsNotPossessed.RemoveAt(i);
            if (SaveGame.MutationsPossessed.Count > 0 && mutation.Group != MutationGroup.None)
            {
                int j = 0;
                do
                {
                    if (SaveGame.MutationsPossessed[j].Group == mutation.Group)
                    {
                        Mutation other = SaveGame.MutationsPossessed[j];
                        SaveGame.MutationsPossessed.RemoveAt(j);
                        other.OnLose();
                        SaveGame.MsgPrint(other.LoseMessage);
                        SaveGame.MutationsNotPossessed.Add(other);
                    }
                    else
                    {
                        j++;
                    }
                } while (j < SaveGame.MutationsPossessed.Count);
            }
            SaveGame.MutationsPossessed.Add(mutation);
            mutation.OnGain();
            SaveGame.MsgPrint(mutation.GainMessage);
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
            SaveGame.HandleStuff();
            return;
        }
        SaveGame.MsgPrint("Oops! Fell out of mutation list!");
    }
}
