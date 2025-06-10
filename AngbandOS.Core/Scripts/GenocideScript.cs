// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GenocideScript : Script, IScript, ICastSpellScript, IScriptBool, IReadScrollOrUseStaffScript, IActivateItemScript
{
    private GenocideScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public void ExecuteScriptBool(bool playerCast) // TODO: This needs to be cancellable and remove the playerCast parameter
    {
        int msec = Constants.DelayFactorInMilliseconds;
        Game.GetCom("Choose a monster race (by symbol) to carnage: ", out char typ);
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
            if (rPtr.Symbol.Character != typ)
            {
                continue;
            }
            if (rPtr.Guardian)
            {
                continue;
            }
            Game.DeleteMonsterByIndex(i, true);
            if (playerCast) // TODO: Move this to the caller
            {
                Game.TakeHit(Game.DieRoll(4), "the strain of casting Carnage");
            }
            Game.ConsoleView.MoveCursorTo(Game.MapY.IntValue, Game.MapX.IntValue);
            Game.HandleStuff();
            Game.UpdateScreen();
            Game.Pause(msec);
        }
    }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(true, true);
    }

    /// <summary>
    /// Executes the Bool script with a PlayerCast parameter value of true.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScriptBool(true);
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return new UsedResult(true);
    }
    public string LearnedDetails => "";
}
