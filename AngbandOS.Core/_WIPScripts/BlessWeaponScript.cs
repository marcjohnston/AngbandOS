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
        if (oPtr.EffectiveAttributeSet.IsCursed)
        {
            if ((oPtr.EffectiveAttributeSet.HeavyCurse && Game.DieRoll(100) < 33) || oPtr.EffectiveAttributeSet.PermaCurse)
            {
                Game.MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                return;
            }
            Game.MsgPrint($"A malignant aura leaves {your} {oName}.");
            oPtr.EffectiveAttributeSet.IsCursed = false;
            oPtr.IdentSense = true;
            oPtr.Inscription = "uncursed";
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        }
        if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(BlessedAttribute)).Get())
        {
            string s = oPtr.StackCount > 1 ? "were" : "was";
            Game.MsgPrint($"{your} {oName} {s} blessed already.");
            return;
        }
        if (!oPtr.IsArtifact || Game.DieRoll(3) == 1)
        {
            string s = oPtr.StackCount > 1 ? "" : "s";
            Game.MsgPrint($"{your} {oName} shine{s}!");
            oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(BlessedAttribute)).Set();
        }
        else
        {
            bool disHappened = false;
            Game.MsgPrint("The artifact resists your blessing!");
            if (oPtr.EffectiveAttributeSet.MeleeToHit > 0)
            {
                oPtr.EffectiveAttributeSet.MeleeToHit--;
                disHappened = true;
            }
            if (oPtr.EffectiveAttributeSet.MeleeToHit > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EffectiveAttributeSet.MeleeToHit--;
            }
            if (oPtr.EffectiveAttributeSet.ToDamage > 0)
            {
                oPtr.EffectiveAttributeSet.ToDamage--;
                disHappened = true;
            }
            if (oPtr.EffectiveAttributeSet.ToDamage > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EffectiveAttributeSet.ToDamage--;
            }
            if (oPtr.EffectiveAttributeSet.BonusArmorClass > 0)
            {
                oPtr.EffectiveAttributeSet.BonusArmorClass--;
                disHappened = true;
            }
            if (oPtr.EffectiveAttributeSet.BonusArmorClass > 5 && Game.RandomLessThan(100) < 33)
            {
                oPtr.EffectiveAttributeSet.BonusArmorClass--;
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
