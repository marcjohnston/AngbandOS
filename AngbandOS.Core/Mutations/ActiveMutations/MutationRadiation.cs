// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationRadiation : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(15, 15, Ability.Constitution, 14))
        {
            return;
        }
        saveGame.MsgPrint("Radiation flows from your body!");
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<NukeProjectile>(), 0, saveGame.ExperienceLevel * 2, 3 + (saveGame.ExperienceLevel / 20));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 15
            ? "produce radiation   (unusable until level 15)"
            : "produce radiation   (cost 15, CON based)";
    }

    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "You start emitting hard radiation.";
        HaveMessage = "You can emit hard radiation at will.";
        LoseMessage = "You stop emitting hard radiation.";
    }
}