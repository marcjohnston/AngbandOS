namespace AngbandOS.Core.Scripts;
internal class WarningRandomMutationMutationScript : UniversalScript, IGetKey
{
    private WarningRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(1000) != 1)
        {
            return;
        }
        int dangerAmount = 0;
        for (int monster = 0; monster < Game.MonsterMax; monster++)
        {
            Monster mPtr = Game.Monsters[monster];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Level >= Game.ExperienceLevel.IntValue)
            {
                dangerAmount += rPtr.Level - Game.ExperienceLevel.IntValue + 1;
            }
        }
        if (dangerAmount > 100)
        {
            Game.MsgPrint("You feel utterly terrified!");
        }
        else if (dangerAmount > 50)
        {
            Game.MsgPrint("You feel terrified!");
        }
        else if (dangerAmount > 20)
        {
            Game.MsgPrint("You feel very worried!");
        }
        else if (dangerAmount > 10)
        {
            Game.MsgPrint("You feel paranoid!");
        }
        else if (dangerAmount > 5)
        {
            Game.MsgPrint("You feel almost safe.");
        }
        else
        {
            Game.MsgPrint("You feel lonely.");
        }
    }
}