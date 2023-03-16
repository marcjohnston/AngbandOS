// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations
{
    [Serializable]
    internal class MutationShriek : Mutation
    {
        public override void Activate(SaveGame saveGame)
        {
            if (!saveGame.CheckIfRacialPowerWorks(4, 4, Ability.Constitution, 6))
            {
                return;
            }
            saveGame.FireBall(new SoundProjectile(saveGame), 0, 4 * saveGame.Player.Level, 8);
            saveGame.AggravateMonsters();
        }

        public override string ActivationSummary(int lvl)
        {
            return lvl < 4 ? "shriek           (unusable until level 4)" : "shriek           (cost 4, CON based)";
        }

        public override void Initialize()
        {
            Frequency = 3;
            GainMessage = "Your vocal cords get much tougher.";
            HaveMessage = "You can emit a horrible shriek.";
            LoseMessage = "Your vocal cords get much weaker.";
        }
    }
}