// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PolymorphWoundsScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private PolymorphWoundsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the polymorph-wounds script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the polymorph-wounds script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int wounds = Game.BleedingTimer.Value;
        int hitP = Game.MaxHealth.IntValue - Game.Health.IntValue;
        int change = Game.DiceRoll(Game.ExperienceLevel.IntValue, 5);
        bool nastyEffect = Game.DieRoll(5) == 1;
        if (!(wounds != 0 || hitP != 0 || nastyEffect))
        {
            return;
        }
        if (nastyEffect)
        {
            Game.MsgPrint("A new wound was created!");
            Game.TakeHit(change, "a polymorphed wound");
            Game.BleedingTimer.SetTimer(change);
        }
        else
        {
            Game.MsgPrint("Your wounds are polymorphed into less serious ones.");
            Game.RestoreHealth(change);
            Game.BleedingTimer.SetTimer(Game.BleedingTimer.Value - (change / 2));
        }
        return;
    }
}
