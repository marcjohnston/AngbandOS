﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ConstitutionDartScript : Script, IScript, ICastSpellScript
{
    private ConstitutionDartScript(Game game) : base(game) { }

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
        // Dart traps need a to-hit roll
        if (Game.TrapCheckHitOnPlayer(125))
        {
            Game.MsgPrint("A small dart hits you!");
            // Do 1d4 damage plus constitution drain
            int damage = Game.DiceRoll(1, 4);
            Game.TakeHit(damage, "a dart trap");
            Game.TryDecreasingAbilityScore(Game.ConstitutionAbility);
        }
        else
        {
            Game.MsgPrint("A small dart barely misses you.");
        }
    }
}
