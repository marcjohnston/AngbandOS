// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class SpeedFluxRandomMutation : Mutation
{
    private SpeedFluxRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You have become unstuck in time.";
    public override string HaveMessage => "You move faster or slower randomly.";
    public override string LoseMessage => "You are firmly anchored in time.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(6000) == 1)
        {
            Game.Disturb(false);
            if (base.Game.DieRoll(2) == 1)
            {
                Game.MsgPrint("Everything around you speeds up.");
                if (Game.HasteTimer.Value > 0)
                {
                    Game.HasteTimer.ResetTimer();
                }
                else
                {
                    Game.SlowTimer.AddTimer(base.Game.DieRoll(30) + 10);
                }
            }
            else
            {
                Game.MsgPrint("Everything around you slows down.");
                if (Game.SlowTimer.Value > 0)
                {
                    Game.SlowTimer.ResetTimer();
                }
                else
                {
                    Game.HasteTimer.AddTimer(base.Game.DieRoll(30) + 10);
                }
            }
            Game.MsgPrint(string.Empty);
        }
    }
}