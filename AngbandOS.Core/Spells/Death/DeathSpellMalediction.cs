// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death
{
    [Serializable]
    internal class DeathSpellMalediction : Spell
    {
        private DeathSpellMalediction(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new HellFireProjectile(saveGame), dir,
                Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 5), 3), 0);
            if (Program.Rng.DieRoll(5) != 1)
            {
                return;
            }
            int dummy = Program.Rng.DieRoll(1000);
            if (dummy == 666)
            {
                saveGame.FireBolt(new DeathRayProjectile(saveGame), dir, saveGame.Player.Level);
            }
            if (dummy < 500)
            {
                saveGame.FireBolt(new TurnAllProjectile(saveGame), dir, saveGame.Player.Level);
            }
            if (dummy < 800)
            {
                saveGame.FireBolt(new OldConfProjectile(saveGame), dir, saveGame.Player.Level);
            }
            saveGame.FireBolt(new StunProjectile(saveGame), dir, saveGame.Player.Level);
        }

        public override string Name => "Malediction";
        
        protected override string Comment(Player player)
        {
            return $"dam {3 + ((player.Level - 1) / 5)}d3";
        }
    }
}