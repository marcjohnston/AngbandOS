// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationBrFire : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(20, saveGame.ExperienceLevel, Ability.Constitution, 18))
        {
            return;
        }
        saveGame.MsgPrint("You breathe fire...");
        if (saveGame.GetDirectionWithAim(out int dir))
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, saveGame.ExperienceLevel * 2, -(1 + (saveGame.ExperienceLevel / 20)));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20
            ? "fire breath      (unusable until level 20)"
            : $"fire breath      (cost {lvl}, dam {lvl * 2}, CON based)";
    }

    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "You gain the ability to breathe fire.";
        HaveMessage = "You can breathe fire (dam lvl * 2).";
        LoseMessage = "You lose the ability to breathe fire.";
    }
}