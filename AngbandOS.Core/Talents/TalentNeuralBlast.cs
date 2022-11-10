// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Projection;
using System;

namespace AngbandOS.Talents
{
    [Serializable]
    internal class TalentNeuralBlast : Talent
    {
        public override void Initialise(int characterClass)
        {
            Name = "Neural Blast";
            Level = 2;
            ManaCost = 1;
            BaseFailure = 20;
        }

        public override void Use(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            if (saveGame.Rng.DieRoll(100) < saveGame.Player.Level * 2)
            {
                saveGame.FireBeam(new ProjectPsi(saveGame), dir, saveGame.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 4), 3 + (saveGame.Player.Level / 15)));
            }
            else
            {
                saveGame.FireBall(new ProjectPsi(saveGame), dir, saveGame.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 4), 3 + (saveGame.Player.Level / 15)), 0);
            }
        }

        protected override string Comment(Player player)
        {
            return $"dam {3 + ((player.Level - 1) / 4)}d{3 + (player.Level / 15)}";
        }
    }
}