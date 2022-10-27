// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System;

namespace AngbandOS.Talents
{
    [Serializable]
    internal class TalentCharacterArmour : Talent
    {
        public override void Initialise(int characterClass)
        {
            Name = "Character Armour";
            Level = 13;
            ManaCost = 12;
            BaseFailure = 50;
        }

        public override void Use(SaveGame saveGame)
        {
            saveGame.Player.SetTimedStoneskin(saveGame.Player.TimedStoneskin + saveGame.Player.Level);
            if (saveGame.Player.Level > 14)
            {
                saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + saveGame.Player.Level);
            }
            if (saveGame.Player.Level > 19)
            {
                saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + saveGame.Player.Level);
            }
            if (saveGame.Player.Level > 24)
            {
                saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + saveGame.Player.Level);
            }
            if (saveGame.Player.Level > 29)
            {
                saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + saveGame.Player.Level);
            }
            if (saveGame.Player.Level > 34)
            {
                saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + saveGame.Player.Level);
            }
        }

        protected override string Comment(Player player)
        {
            return $"dur {player.Level}";
        }
    }
}