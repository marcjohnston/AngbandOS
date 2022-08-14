// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System;

namespace Cthangband.Talents
{
    [Serializable]
    internal class TalentAdrenalineChanneling : Talent
    {
        public override void Initialise(int characterClass)
        {
            Name = "Adrenaline Channeling";
            Level = 23;
            ManaCost = 15;
            BaseFailure = 50;
        }

        public override void Use(SaveGame saveGame)
        {
            saveGame.Player.SetTimedFear(0);
            saveGame.Player.SetTimedStun(0);
            saveGame.Player.RestoreHealth(saveGame.Player.Level);
            int i = 10 + Program.Rng.DieRoll(saveGame.Player.Level * 3 / 2);
            if (saveGame.Player.Level < 35)
            {
                saveGame.Player.SetTimedHeroism(saveGame.Player.TimedHeroism + i);
            }
            else
            {
                saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + i);
            }
            if (saveGame.Player.TimedHaste == 0)
            {
                saveGame.Player.SetTimedHaste(i);
            }
            else
            {
                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + i);
            }
        }

        protected override string Comment(Player player)
        {
            return $"dur 10+d{player.Level * 3 / 2}";
        }
    }
}