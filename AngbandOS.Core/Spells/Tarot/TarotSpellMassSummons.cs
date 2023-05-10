// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellMassSummons : Spell
    {
        private TarotSpellMassSummons(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            bool noneCame = true;
            saveGame.MsgPrint("You concentrate on several images at once...");
            for (int dummy = 0; dummy < 3 + (saveGame.Player.Level / 10); dummy++)
            {
                if (Program.Rng.DieRoll(10) > 3)
                {
                    if (saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new NoUniquesMonsterSelector(), false))
                    {
                        noneCame = false;
                    }
                }
                else if (saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, null))
                {
                    saveGame.MsgPrint("A summoned creature gets angry!");
                    noneCame = false;
                }
            }
            if (noneCame)
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override string Name => "Mass Summons";
        
        protected override string Comment(Player player)
        {
            return "control 70%";
        }
    }
}