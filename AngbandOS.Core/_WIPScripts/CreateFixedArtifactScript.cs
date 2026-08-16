// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class CreateFixedArtifactScript : Script, IScript, ICastSpellScript
{
    private CreateFixedArtifactScript(Game game) : base(game) { }

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
        FixedArtifact[] fixedArtifacts = Game.SingletonRepository.Get<FixedArtifact>().OrderBy(_fixedArtifact => _fixedArtifact.Name).ToArray();
        ConsoleTableWithRowHighlighting<FixedArtifact> table = new ConsoleTableWithRowHighlighting<FixedArtifact>(fixedArtifacts, new (string, Func<FixedArtifact, string>)[] {
            ("Name", _fixedArtifact => _fixedArtifact.Name),            
            ("Level", _fixedArtifact => _fixedArtifact.Level.ToString())
        });
        FixedArtifact? selectedFixedArtifact = Game.SelectFromConsoleTable<FixedArtifact>(table, "Spawn Which Fixed Artifact?");
        if (selectedFixedArtifact is not null)
        {
            // Create a compatible item.
            Item qPtr = new Item(Game, selectedFixedArtifact.BaseItemFactory);
            // Apply the fixed artifact.
            if (qPtr.ApplyFixedArtifact(selectedFixedArtifact))
            {
                Game.DropNear(qPtr, null, Game.MapY.IntValue, Game.MapX.IntValue);
                Game.MsgPrint("Allocated.");
            }
        }

    }
}
