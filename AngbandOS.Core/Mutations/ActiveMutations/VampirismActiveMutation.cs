// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class VampirismActiveMutation : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(13, saveGame.ExperienceLevel, Ability.Constitution, 14))
        {
            return;
        }
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (saveGame.DrainLife(dir, saveGame.ExperienceLevel * 2))
        {
            saveGame.RestoreHealth(saveGame.ExperienceLevel + Program.Rng.DieRoll(saveGame.ExperienceLevel));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 13
            ? "vampiric drain   (unusable until level 13)"
            : $"vampiric drain   (cost {lvl}, CON based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You become vampiric.";
    public override string HaveMessage => "You can drain life from a foe like a vampire.";
    public override string LoseMessage => "You are no longer vampiric.";
}