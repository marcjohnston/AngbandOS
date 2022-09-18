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
    internal class TalentPrecognition : Talent
    {
        public override void Initialise(int characterClass)
        {
            Name = "Precognition";
            Level = 1;
            ManaCost = 1;
            BaseFailure = 15;
        }

        public override void Use(SaveGame saveGame)
        {
            if (saveGame.Player.Level > 44)
            {
                saveGame.Level.WizLight();
            }
            else if (saveGame.Player.Level > 19)
            {
                saveGame.Level.MapArea();
            }
            bool b;
            if (saveGame.Player.Level < 30)
            {
                b = saveGame.DetectMonstersNormal();
                if (saveGame.Player.Level > 14)
                {
                    b |= saveGame.DetectMonstersInvis();
                }
                if (saveGame.Player.Level > 4)
                {
                    b |= saveGame.DetectTraps();
                }
            }
            else
            {
                b = saveGame.DetectAll();
            }
            if (saveGame.Player.Level > 24 && saveGame.Player.Level < 40)
            {
                saveGame.Player.SetTimedTelepathy(saveGame.Player.TimedTelepathy + saveGame.Player.Level);
            }
            if (!b)
            {
                saveGame.MsgPrint("You feel safe.");
            }
        }

        protected override string Comment(Player player)
        {
            return string.Empty;
        }
    }
}