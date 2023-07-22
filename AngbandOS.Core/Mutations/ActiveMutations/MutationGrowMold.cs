// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationGrowMold : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(1, 6, Ability.Constitution, 14))
        {
            return;
        }
        for (int i = 0; i < 8; i++)
        {
            saveGame.Level.SummonSpecificFriendly(saveGame.MapY, saveGame.MapX, saveGame.ExperienceLevel, new Bizarre1MonsterSelector(), false);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 1 ? "grow mold        (unusable until level 1)" : "grow mold        (cost 6, CON based)";
    }

    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You feel a sudden affinity for mold.";
        HaveMessage = "You can cause mold to grow near you.";
        LoseMessage = "You feel a sudden dislike for mold.";
    }
}