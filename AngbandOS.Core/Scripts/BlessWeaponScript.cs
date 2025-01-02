// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BlessWeaponScript : Script, IScript, ICastSpellScript, ISuccessByChanceScript
{
    private BlessWeaponScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Blesses a chosen weapon and return true if blessing wasn't cancelled during the weapon selection process; false, if the blessing was cancelled.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Bless which weapon? ", true, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(WeaponsItemFilter))))
        {
            Game.MsgPrint("You have no weapon to bless.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        string your = oPtr.IsInInventory ? "your" : "the"; ;
        string oName = oPtr.GetDescription(false);
        ItemCharacteristics mergedCharacteristics = oPtr.GetMergedCharacteristics();
        if (oPtr.IsCursed)
        {
            if ((mergedCharacteristics.HeavyCurse && Game.DieRoll(100) < 33) || mergedCharacteristics.PermaCurse)
            {
                Game.MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                return true;
            }
            Game.MsgPrint($"A malignant aura leaves {your} {oName}.");
            oPtr.IsCursed = false;
            oPtr.IdentSense = true;
            oPtr.Inscription = "uncursed";
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        }
        if (mergedCharacteristics.Blessed)
        {
            string s = oPtr.StackCount > 1 ? "were" : "was";
            Game.MsgPrint($"{your} {oName} {s} blessed already.");
            return true;
        }
        if (!oPtr.IsArtifact || Game.DieRoll(3) == 1)
        {
            string s = oPtr.StackCount > 1 ? "" : "s";
            Game.MsgPrint($"{your} {oName} shine{s}!");
            oPtr.Characteristics.Blessed = true;
        }
        else
        {
            bool disHappened = false;
            Game.MsgPrint("The artifact resists your blessing!");
            if (oPtr.Characteristics.BonusHit > 0)
            {
                oPtr.Characteristics.BonusHit--;
                disHappened = true;
            }
            if (oPtr.Characteristics.BonusHit > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.Characteristics.BonusHit--;
            }
            if (oPtr.Characteristics.BonusDamage > 0)
            {
                oPtr.Characteristics.BonusDamage--;
                disHappened = true;
            }
            if (oPtr.Characteristics.BonusDamage > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.Characteristics.BonusDamage--;
            }
            if (oPtr.Characteristics.BonusArmorClass > 0)
            {
                oPtr.Characteristics.BonusArmorClass--;
                disHappened = true;
            }
            if (oPtr.Characteristics.BonusArmorClass > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.Characteristics.BonusArmorClass--;
            }
            if (disHappened)
            {
                Game.MsgPrint("There is a  feeling in the air...");
                string s = oPtr.StackCount > 1 ? "were" : "was";
                Game.MsgPrint($"{your} {oName} {s} disenchanted!");
            }
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }
}
