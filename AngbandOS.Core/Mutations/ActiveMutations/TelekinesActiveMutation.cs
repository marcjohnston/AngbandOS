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
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(9, 9, Ability.Wisdom, 14))
        {
            return;
        }
        saveGame.MsgPrint("You concentrate...");
        if (saveGame.GetDirectionWithAim(out int dir))
        {
            saveGame.SummonItem(dir, saveGame.ExperienceLevel * 10, true);
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