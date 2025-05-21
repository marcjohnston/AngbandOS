// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AnnihilationScript : Script, IScript, ICastSpellScript
{
    private AnnihilationScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Destroys every monster, taking a hit for each one but adding mana for each too.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.Mana.IntValue -= 100;
        for (int i = 1; i < Game.MonsterMax; i++)
        {
            Monster mPtr = Game.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Unique)
            {
                continue;
            }
            if (rPtr.Guardian)
            {
                continue;
            }
            Game.DeleteMonsterByIndex(i, true);
            Game.TakeHit(Game.DieRoll(4), "the strain of casting Annihilation");
            Game.Mana.IntValue++;
            Game.ConsoleView.MoveCursorTo(Game.MapY.IntValue, Game.MapX.IntValue);
            Game.HandleStuff();
            Game.UpdateScreen();
            Game.Pause(Constants.DelayFactorInMilliseconds);
        }
        Game.Mana.IntValue += 100;
    }
}
