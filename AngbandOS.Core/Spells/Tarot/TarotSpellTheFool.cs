// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.MonsterSelectors;
using AngbandOS.Enumerations;

namespace AngbandOS.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellTheFool : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            MonsterSelector? summonType = null;
            saveGame.MsgPrint("You concentrate on the Fool card...");
            switch (Program.Rng.DieRoll(4))
            {
                case 1:
                    summonType = new Bizarre1MonsterSelector();
                    break;

                case 2:
                    summonType = new Bizarre2MonsterSelector();
                    break;

                case 3:
                    summonType = new Bizarre4MonsterSelector();
                    break;

                case 4:
                    summonType = new Bizarre5MonsterSelector();
                    break;
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                saveGame.MsgPrint(saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, summonType)
                    ? "The summoned creature gets angry!"
                    : "No-one ever turns up.");
            }
            else
            {
                if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, summonType, false))
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
        }

        public override void Initialise(int characterClass)
        {
            Name = "The Fool";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 15;
                    ManaCost = 15;
                    BaseFailure = 80;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.Priest:
                case CharacterClass.Monk:
                    Level = 17;
                    ManaCost = 17;
                    BaseFailure = 80;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.Rogue:
                    Level = 20;
                    ManaCost = 15;
                    BaseFailure = 80;
                    FirstCastExperience = 20;
                    break;

                case CharacterClass.Ranger:
                    Level = 20;
                    ManaCost = 20;
                    BaseFailure = 80;
                    FirstCastExperience = 20;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 19;
                    ManaCost = 18;
                    BaseFailure = 80;
                    FirstCastExperience = 20;
                    break;

                case CharacterClass.HighMage:
                    Level = 11;
                    ManaCost = 11;
                    BaseFailure = 70;
                    FirstCastExperience = 20;
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
            return "control 50%";
        }
    }
}