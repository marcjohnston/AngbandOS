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
    internal class TarotSpellSummonHounds : Spell
    {
        private TarotSpellSummonHounds(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You concentrate on the image of a hound...");
            if (Program.Rng.DieRoll(5) > 2)
            {
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new HoundMonsterSelector(), true))
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
            else if (saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new HoundMonsterSelector()))
            {
                saveGame.MsgPrint("The summoned hounds get angry!");
            }
            else
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override string Name => "Summon Hounds";
        
        protected override string Comment(Player player)
        {
            return "control 60%";
        }
    }
}