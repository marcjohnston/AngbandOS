// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class WizardGainMutationScript : Script, IScript
{
    private WizardGainMutationScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Mutation[] notPossessedMutations = Game.MutationsNotPossessed.OrderBy(_mutation => _mutation.Title).ToArray();
        ConsoleTableWithRowHighlighting<Mutation> table = new ConsoleTableWithRowHighlighting<Mutation>(notPossessedMutations, new (string, Func<Mutation, string>)[] {
            ("Title", _mutation => _mutation.Title)
        });
        Mutation? selectedMutation = Game.SelectFromConsoleTable<Mutation>(table, "Select mutation?");
        if (selectedMutation is not null)
        {
            Game.GainMutation(selectedMutation);
        }
    }
}

