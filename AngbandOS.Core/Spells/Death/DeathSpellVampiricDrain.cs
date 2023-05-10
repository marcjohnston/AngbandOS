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
    internal class DeathSpellVampiricDrain : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int dummy = saveGame.Player.Level + (Program.Rng.DieRoll(saveGame.Player.Level) * Math.Max(1, saveGame.Player.Level / 10));
            if (!saveGame.DrainLife(dir, dummy))
            {
                return;
            }
            saveGame.Player.RestoreHealth(dummy);
            dummy = saveGame.Player.Food + Math.Min(5000, 100 * dummy);
            if (saveGame.Player.Food < Constants.PyFoodMax)
            {
                saveGame.Player.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
            }
        }

        public override string Name => "Vampiric Drain";
        
        protected override string Comment(Player player)
        {
            return $"dam {Math.Max(1, player.Level / 10)}d{player.Level}+{player.Level}";
        }
    }
}