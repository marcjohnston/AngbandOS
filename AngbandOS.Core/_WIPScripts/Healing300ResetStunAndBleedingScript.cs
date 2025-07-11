// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Healing300ResetStunAndBleedingScript : Script, IScript, ICastSpellScript, IReadScrollOrUseStaffScript
{
    private Healing300ResetStunAndBleedingScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        bool isIdentified = false;
        if (Game.RestoreHealth(300))
        {
            isIdentified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.RunIdentifiedScript(nameof(BleedingResetTimerScript)))
        {
            isIdentified = true;
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }

    /// <summary>
    /// Restores 300 points of health and heals stun and bleeding.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteReadScrollOrUseStaffScript();
    }
    public string LearnedDetails => "heal 300";
}
