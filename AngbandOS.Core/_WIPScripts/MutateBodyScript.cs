// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MutateBodyScript : Script, IScript, ICastSpellScript
{
    private MutateBodyScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Gains a mutation.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(GainMutationScript));
    }
    public string LearnedDetails => "";
}
