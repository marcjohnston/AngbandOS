// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationLaserEye : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(7, 10, Ability.Wisdom, 9))
        {
            return;
        }
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBeam(saveGame.SingletonRepository.Projectiles.Get<LightProjectile>(), dir, 2 * saveGame.Player.Level);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "laser eyes        (unusable until level 7)" : "laser eyes        (cost 10, WIS based)";
    }

    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "Your eyes burn for a moment.";
        HaveMessage = "Your eyes can fire laser beams.";
        LoseMessage = "Your eyes burn for a moment, then feel soothed.";
    }
}