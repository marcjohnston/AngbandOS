// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class HypnGazeActiveMutation : Mutation
{
    private HypnGazeActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(12, 12, Ability.Charisma, 18))
        {
            return;
        }
        SaveGame.MsgPrint("Your eyes look mesmerizing...");
        if (SaveGame.GetDirectionWithAim(out int dir))
        {
            SaveGame.CharmMonster(dir, SaveGame.ExperienceLevel.Value);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20 ? "hypnotic gaze    (unusable until level 12)" : "hypnotic gaze    (cost 12, CHA based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "Your eyes look mesmerizing...";
    public override string HaveMessage => "Your gaze is hypnotic.";
    public override string LoseMessage => "Your eyes look uninteresting.";
}