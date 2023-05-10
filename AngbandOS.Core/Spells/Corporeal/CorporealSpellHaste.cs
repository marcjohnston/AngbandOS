// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal
{
    [Serializable]
    internal class CorporealSpellHaste : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (saveGame.Player.TimedHaste.TurnsRemaining == 0)
            {
                saveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + saveGame.Player.Level) + saveGame.Player.Level);
            }
            else
            {
                saveGame.Player.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
            }
        }

        public override string Name => "Haste";
        
        protected override string Comment(Player player)
        {
            return $"dur {player.Level}+d{20 + player.Level}";
        }
    }
}