// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellDimensionDoor : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You open a dimensional gate. Choose a destination.");
            if (!saveGame.TgtPt(out int ii, out int ij))
            {
                return;
            }
            saveGame.Player.Energy -= 60 - saveGame.Player.Level;
            if (!saveGame.Level.GridPassableNoCreature(ij, ii) || saveGame.Level.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
                saveGame.Level.Distance(ij, ii, saveGame.Player.MapY, saveGame.Player.MapX) > saveGame.Player.Level + 2 ||
                Program.Rng.RandomLessThan(saveGame.Player.Level * saveGame.Player.Level / 2) == 0)
            {
                saveGame.MsgPrint("You fail to exit the astral plane correctly!");
                saveGame.Player.Energy -= 100;
                saveGame.TeleportPlayer(10);
            }
            saveGame.TeleportPlayerTo(ij, ii);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Dimension Door";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 9;
                    ManaCost = 9;
                    BaseFailure = 60;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.Priest:
                case CharacterClass.Monk:
                    Level = 11;
                    ManaCost = 11;
                    BaseFailure = 60;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.Rogue:
                    Level = 15;
                    ManaCost = 13;
                    BaseFailure = 60;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.Ranger:
                    Level = 17;
                    ManaCost = 15;
                    BaseFailure = 60;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 12;
                    ManaCost = 12;
                    BaseFailure = 60;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.HighMage:
                    Level = 7;
                    ManaCost = 7;
                    BaseFailure = 50;
                    FirstCastExperience = 6;
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
            return $"range {player.Level + 2}";
        }
    }
}