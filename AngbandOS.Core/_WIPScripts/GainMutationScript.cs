// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GainMutationScript : Script, IScript, ICastSpellScript
{
    private GainMutationScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

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
            total += mutation.Frequency; // This here simulates the weighted random but uses frequency as the weight.
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
            Game.GainMutation(mutation);
            return;
        }
        Game.MsgPrint("Oops! Fell out of mutation list!");
    }
}

