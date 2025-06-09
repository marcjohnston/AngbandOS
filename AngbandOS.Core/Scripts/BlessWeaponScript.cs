// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BlessWeaponScript : Script, IScript, ICastSpellScript
{
    private BlessWeaponScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Bless which weapon? ", true, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(WeaponsItemFilter))))
        {
            Game.MsgPrint("You have no weapon to bless.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        string your = oPtr.IsInInventory ? "your" : "the"; ;
        string oName = oPtr.GetDescription(false);
        RoItemPropertySet mergedCharacteristics = oPtr.GetEffectiveItemProperties();
        if (mergedCharacteristics.IsCursed)
        {
            if ((mergedCharacteristics.HeavyCurse && Game.DieRoll(100) < 33) || mergedCharacteristics.PermaCurse)
            {
                Game.MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                return;
            }
            Game.MsgPrint($"A malignant aura leaves {your} {oName}.");
            oPtr.EnchantmentItemProperties.IsCursed = false;
            oPtr.IdentSense = true;
            oPtr.Inscription = "uncursed";
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        }
        if (mergedCharacteristics.Blessed)
        {
            string s = oPtr.StackCount > 1 ? "were" : "was";
            Game.MsgPrint($"{your} {oName} {s} blessed already.");
            return;
        }
        if (!oPtr.IsArtifact || Game.DieRoll(3) == 1)
        {
            string s = oPtr.StackCount > 1 ? "" : "s";
            Game.MsgPrint($"{your} {oName} shine{s}!");
            oPtr.EnchantmentItemProperties.Blessed = true;
        }
        else
        {
            bool disHappened = false;
            Game.MsgPrint("The artifact resists your blessing!");
            if (oPtr.EnchantmentItemProperties.BonusHit > 0)
            {
                oPtr.EnchantmentItemProperties.BonusHit--;
                disHappened = true;
            }
            if (oPtr.EnchantmentItemProperties.BonusHit > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EnchantmentItemProperties.BonusHit--;
            }
            if (oPtr.EnchantmentItemProperties.BonusDamage > 0)
            {
                oPtr.EnchantmentItemProperties.BonusDamage--;
                disHappened = true;
            }
            if (oPtr.EnchantmentItemProperties.BonusDamage > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EnchantmentItemProperties.BonusDamage--;
            }
            if (oPtr.EnchantmentItemProperties.BonusArmorClass > 0)
            {
                oPtr.EnchantmentItemProperties.BonusArmorClass--;
                disHappened = true;
            }
            if (oPtr.EnchantmentItemProperties.BonusArmorClass > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EnchantmentItemProperties.BonusArmorClass--;
            }
            if (disHappened)
            {
                Game.MsgPrint("There is a  feeling in the air...");
                string s = oPtr.StackCount > 1 ? "were" : "was";
                Game.MsgPrint($"{your} {oName} {s} disenchanted!");
            }
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
    }
    public string LearnedDetails => "";
}
