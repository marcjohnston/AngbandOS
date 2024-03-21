// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BlessWeaponScript : Script, IScript, ISuccessfulScript
{
    private BlessWeaponScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Blesses a chosen weapon and return true if blessing wasn't cancelled during the weapon selection process; false, if the blessing was cancelled.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        if (!SaveGame.SelectItem(out Item? oPtr, "Bless which weapon? ", true, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(WeaponsItemFilter))))
        {
            SaveGame.MsgPrint("You have no weapon to bless.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        string your = oPtr.IsInInventory ? "your" : "the"; ;
        string oName = oPtr.Description(false, 0);
        oPtr.RefreshFlagBasedProperties();
        if (oPtr.IdentCursed)
        {
            if ((oPtr.Characteristics.HeavyCurse && SaveGame.DieRoll(100) < 33) || oPtr.Characteristics.PermaCurse)
            {
                SaveGame.MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                return true;
            }
            SaveGame.MsgPrint($"A malignant aura leaves {your} {oName}.");
            oPtr.IdentCursed = false;
            oPtr.IdentSense = true;
            oPtr.Inscription = "uncursed";
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        }
        if (oPtr.Characteristics.Blessed)
        {
            string s = oPtr.Count > 1 ? "were" : "was";
            SaveGame.MsgPrint($"{your} {oName} {s} blessed already.");
            return true;
        }
        if (!oPtr.IsArtifact || SaveGame.DieRoll(3) == 1)
        {
            string s = oPtr.Count > 1 ? "" : "s";
            SaveGame.MsgPrint($"{your} {oName} shine{s}!");
            oPtr.RandomArtifactItemCharacteristics.Blessed = true;
        }
        else
        {
            bool disHappened = false;
            SaveGame.MsgPrint("The artifact resists your blessing!");
            if (oPtr.BonusToHit > 0)
            {
                oPtr.BonusToHit--;
                disHappened = true;
            }
            if (oPtr.BonusToHit > 5 && SaveGame.RandomLessThan(100) < 33)
            {
                oPtr.BonusToHit--;
            }
            if (oPtr.BonusDamage > 0)
            {
                oPtr.BonusDamage--;
                disHappened = true;
            }
            if (oPtr.BonusDamage > 5 && SaveGame.RandomLessThan(100) < 33)
            {
                oPtr.BonusDamage--;
            }
            if (oPtr.BonusArmorClass > 0)
            {
                oPtr.BonusArmorClass--;
                disHappened = true;
            }
            if (oPtr.BonusArmorClass > 5 && SaveGame.RandomLessThan(100) < 33)
            {
                oPtr.BonusArmorClass--;
            }
            if (disHappened)
            {
                SaveGame.MsgPrint("There is a  feeling in the air...");
                string s = oPtr.Count > 1 ? "were" : "was";
                SaveGame.MsgPrint($"{your} {oName} {s} disenchanted!");
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
