// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationHypnGaze : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(12, 12, Ability.Charisma, 18))
        {
            return;
        }
        saveGame.MsgPrint("Your eyes look mesmerizing...");
        if (saveGame.GetDirectionWithAim(out int dir))
        {
            saveGame.CharmMonster(dir, saveGame.Player.Level);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20 ? "hypnotic gaze    (unusable until level 12)" : "hypnotic gaze    (cost 12, CHA based)";
    }

    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "Your eyes look mesmerizing...";
        HaveMessage = "Your gaze is hypnotic.";
        LoseMessage = "Your eyes look uninteresting.";
    }
}