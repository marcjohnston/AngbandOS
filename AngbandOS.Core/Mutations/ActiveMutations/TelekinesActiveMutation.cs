// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class TelekinesActiveMutation : Mutation
{
    private TelekinesActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(9, 9, Game.WisdomAbility, 14))
        {
            return;
        }
        Game.MsgPrint("You concentrate...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Game.SummonItem(dir, Game.ExperienceLevel.IntValue * 10, true);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 9 ? "telekinesis      (unusable until level 9)" : "telekinesis      (cost 9, WIS based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You gain the ability to move objects telekinetically.";
    public override string HaveMessage => "You are telekinetic.";
    public override string LoseMessage => "You lose the ability to move objects telekinetically.";
}