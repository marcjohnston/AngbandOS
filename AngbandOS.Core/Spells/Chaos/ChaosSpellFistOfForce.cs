// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos
{
    [Serializable]
    internal class ChaosSpellFistOfForce : Spell
    {
        private ChaosSpellFistOfForce(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<DisintegrateProjectile>(), dir,
                Program.Rng.DiceRoll(8 + ((SaveGame.Player.Level - 5) / 4), 8), 0);
        }

        public override string Name => "Fist of Force";
        
        protected override string? Info()
        {
            return $"dam {8 + ((SaveGame.Player.Level - 5) / 4)}d8";
        }
    }
}