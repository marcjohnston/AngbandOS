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
    private VampirismActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(13, SaveGame.ExperienceLevel.Value, Ability.Constitution, 14))
        {
            return;
        }
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (SaveGame.DrainLife(dir, SaveGame.ExperienceLevel.Value * 2))
        {
            SaveGame.RestoreHealth(SaveGame.ExperienceLevel.Value + base.SaveGame.DieRoll(SaveGame.ExperienceLevel.Value));
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