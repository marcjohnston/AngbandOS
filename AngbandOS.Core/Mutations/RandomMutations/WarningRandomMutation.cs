// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class WarningRandomMutation : Mutation
{
    private WarningRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You suddenly feel paranoid.";
    public override string HaveMessage => "You receive warnings about your foes.";
    public override string LoseMessage => "You no longer feel paranoid.";

    public override void ProcessWorld()
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