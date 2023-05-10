// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life
{
    [Serializable]
    internal class LifeSpellHealing : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Player.RestoreHealth(300);
            saveGame.Player.TimedStun.ResetTimer();
            saveGame.Player.TimedBleeding.ResetTimer();
        }

        public override string Name => "Healing";
        
        protected override string Comment(Player player)
        {
            return "heal 300";
        }
    }
}