// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateRandomArtifactScript : Script, IScript
{
    private CreateRandomArtifactScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Creates an artifact from a chosen item.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool okay;
        if (!SaveGame.SelectItem(out Item? oPtr, "Enchant which item? ", true, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(WeaponsItemFilter))))
        {
            SaveGame.MsgPrint("You have nothing to enchant.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        string oName = oPtr.Description(false, 0);
        string your = oPtr.IsInInventory ? "Your" : "The";
        string s = oPtr.Count > 1 ? "" : "s";
        SaveGame.MsgPrint($"{your} {oName} radiate{s} a blinding light!");
        if (oPtr.IsArtifact)
        {
            string are = oPtr.Count > 1 ? "are" : "is";
            s = oPtr.Count > 1 ? "artifacts" : "an artifact";
            SaveGame.MsgPrint($"The {oName} {are} already {s}!");
            okay = false;
        }
        else if (oPtr.RareItem != null)
        {
            string are = oPtr.Count > 1 ? "are" : "is";
            s = oPtr.Count > 1 ? "rare items" : "a rare item";
            SaveGame.MsgPrint($"The {oName} {are} already {s}!");
            okay = false;
        }
        else
        {
            if (oPtr.Count > 1)
            {
                SaveGame.MsgPrint("Not enough energy to enchant more than one object!");
                s = oPtr.Count > 2 ? "were" : "was";
                SaveGame.MsgPrint($"{oPtr.Count - 1} of your oName {s} destroyed!");
                oPtr.Count = 1;
            }
            okay = oPtr.CreateRandomArtifact(true);
        }
        if (!okay)
        {
            SaveGame.MsgPrint("The enchantment failed.");
        }
    }
}
