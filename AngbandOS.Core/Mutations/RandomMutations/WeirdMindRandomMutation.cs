// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class WeirdMindRandomMutation : Mutation
{
    private WeirdMindRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Your thoughts suddenly take off in strange directions.";
    public override string HaveMessage => "Your mind randomly expands and contracts.";
    public override string LoseMessage => "Your thoughts return to boring paths.";

    public override void ProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        if (Game.TelepathyTimer.Value > 0)
        {
            Game.MsgPrint("Your mind feels cloudy!");
            Game.TelepathyTimer.ResetTimer();
        }
        else
        {
            Game.MsgPrint("Your mind expands!");
            Game.TelepathyTimer.SetTimer(Game.ExperienceLevel.IntValue);
        }
    }
}