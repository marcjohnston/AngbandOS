// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EditItemScript : Script, IScript
{
    private EditItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows the wizard to edit an item.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.SelectItem(out Item? item, "Select an item to edit:", true, true, true, null);
        if (item == null)
        {
            return;
        }
        do
        {
            if (!SaveGame.GetString("Rare Item Index: ", out string tmpVal, "", 9))
            {
                return;
            }
            if (int.TryParse(tmpVal, out int val))
            {
                if (!SaveGame.GetBool($"Ok Item (0=False, 1=True)? ", out bool ok))
                {
                    return;
                }
                if (!SaveGame.GetBool($"Good Item (0=False, 1=True)? ", out bool good))
                {
                    return;
                }
                if (!SaveGame.GetBool($"Great Item (0=False, 1=True)? ", out bool great))
                {
                    return;
                }
                item.RareItem = SaveGame.SingletonRepository.RareItems[val];
                item.ApplyMagic(SaveGame.Difficulty, ok, good, great, null);
                break;
            }
        } while (true);
    }
}
