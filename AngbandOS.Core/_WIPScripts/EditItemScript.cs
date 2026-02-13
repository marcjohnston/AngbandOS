// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EditItemScript : Script, IScript, ICastSpellScript
{
    private EditItemScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Allows the wizard to edit an item.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.SelectItem(out Item? item, "Select an item to edit:", true, true, true, null);
        if (item == null)
        {
            return;
        }
        do
        {
            if (!Game.GetString("Rare Item Index: ", out string tmpVal, "", 9))
            {
                return;
            }
            if (int.TryParse(tmpVal, out int val))
            {
                if (!Game.GetBool($"Allow Fixed Artifact Item (0=False, 1=True)? ", out bool allowFixedArtifact))
                {
                    return;
                }
                if (!Game.GetBool($"Good Item (0=False, 1=True)? ", out bool good))
                {
                    return;
                }
                if (!Game.GetBool($"Great Item (0=False, 1=True)? ", out bool great))
                {
                    return;
                }
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(val));
                item.EnchantItem(Game.Difficulty, allowFixedArtifact, good, great, false);
                break;
            }
        } while (true);
    }
}
