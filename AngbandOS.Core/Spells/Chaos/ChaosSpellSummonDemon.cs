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
    internal class ChaosSpellSummonDemon : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level * 3 / 2, new DemonMonsterSelector()))
                {
                    saveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    saveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
                }
                else
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
            else
            {
                if (saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level * 3 / 2, new DemonMonsterSelector(), saveGame.Player.Level == 50))
                {
                    saveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    saveGame.MsgPrint("'What is thy bidding... Master?'");
                }
                else
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
        }

        public override string Name => "Summon Demon";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 47;
                    ManaCost = 100;
                    BaseFailure = 90;
                    FirstCastExperience = 250;
                    break;

                case CharacterClass.Priest:
                    Level = 49;
                    ManaCost = 100;
                    BaseFailure = 90;
                    FirstCastExperience = 250;
                    break;

                case CharacterClass.Ranger:
                    Level = 99;
                    ManaCost = 0;
                    BaseFailure = 0;
                    FirstCastExperience = 0;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 50;
                    ManaCost = 111;
                    BaseFailure = 80;
                    FirstCastExperience = 250;
                    break;

                case CharacterClass.Fanatic:
                    Level = 47;
                    ManaCost = 100;
                    BaseFailure = 80;
                    FirstCastExperience = 250;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 44;
                    ManaCost = 90;
                    BaseFailure = 80;
                    FirstCastExperience = 250;
                    break;

                default:
                    Level = 99;
                    ManaCost = 0;
                    BaseFailure = 0;
                    FirstCastExperience = 0;
                    break;
            }
        }

        protected override string Comment(Player player)
        {
            return "control 67%";
        }
    }
}