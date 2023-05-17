namespace AngbandOS.Core.BirthStages
{
    internal class RaceSelectionBirthStage : BaseBirthStage
    {
        private RaceSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.SingletonRepository.Races
                .OrderBy((Race race) => race.Title)
                .Select((Race race) => race.Title)
                .ToArray();
        }

        public override void RenderSelection(int index)
        {
            Race[] races = SaveGame.SingletonRepository.Races
                .OrderBy((Race race) => race.Title)
                .ToArray();
            Race race = races[index];
            SaveGame.Screen.Print(Colour.Purple, "STR:", 36, 21);
            SaveGame.Screen.Print(Colour.Purple, "INT:", 37, 21);
            SaveGame.Screen.Print(Colour.Purple, "WIS:", 38, 21);
            SaveGame.Screen.Print(Colour.Purple, "DEX:", 39, 21);
            SaveGame.Screen.Print(Colour.Purple, "CON:", 40, 21);
            SaveGame.Screen.Print(Colour.Purple, "CHA:", 41, 21);
            for (int i = 0; i < 6; i++)
            {
                int bonus = race.AbilityBonus[i] + SaveGame.Player.BaseCharacterClass.AbilityBonus[i];
                SaveGame.DisplayStatBonus(26, 36 + i, bonus);
            }
            SaveGame.Screen.Print(Colour.Purple, "Disarming   :", 36, 53);
            SaveGame.Screen.Print(Colour.Purple, "Magic Device:", 37, 53);
            SaveGame.Screen.Print(Colour.Purple, "Saving Throw:", 38, 53);
            SaveGame.Screen.Print(Colour.Purple, "Stealth     :", 39, 53);
            SaveGame.Screen.Print(Colour.Purple, "Fighting    :", 40, 53);
            SaveGame.Screen.Print(Colour.Purple, "Shooting    :", 41, 53);
            SaveGame.Screen.Print(Colour.Purple, "Experience  :", 36, 31);
            SaveGame.Screen.Print(Colour.Purple, "Hit Dice    :", 37, 31);
            SaveGame.Screen.Print(Colour.Purple, "Infravision :", 38, 31);
            SaveGame.Screen.Print(Colour.Purple, "Searching   :", 39, 31);
            SaveGame.Screen.Print(Colour.Purple, "Perception  :", 40, 31);
            SaveGame.DisplayAPlusB(67, 36, SaveGame.Player.BaseCharacterClass.BaseDisarmBonus + race.BaseDisarmBonus, SaveGame.Player.BaseCharacterClass.DisarmBonusPerLevel);
            SaveGame.DisplayAPlusB(67, 37, SaveGame.Player.BaseCharacterClass.BaseDeviceBonus + race.BaseDeviceBonus, SaveGame.Player.BaseCharacterClass.DeviceBonusPerLevel);
            SaveGame.DisplayAPlusB(67, 38, SaveGame.Player.BaseCharacterClass.BaseSaveBonus + race.BaseSaveBonus, SaveGame.Player.BaseCharacterClass.SaveBonusPerLevel);
            SaveGame.DisplayAPlusB(67, 39, (SaveGame.Player.BaseCharacterClass.BaseStealthBonus * 4) + (race.BaseStealthBonus * 4), SaveGame.Player.BaseCharacterClass.StealthBonusPerLevel * 4);
            SaveGame.DisplayAPlusB(67, 40, SaveGame.Player.BaseCharacterClass.BaseMeleeAttackBonus + race.BaseMeleeAttackBonus, SaveGame.Player.BaseCharacterClass.MeleeAttackBonusPerLevel);
            SaveGame.DisplayAPlusB(67, 41, SaveGame.Player.BaseCharacterClass.BaseRangedAttackBonus + race.BaseRangedAttackBonus, SaveGame.Player.BaseCharacterClass.RangedAttackBonusPerLevel);
            SaveGame.Screen.Print(Colour.Black, race.ExperienceFactor + SaveGame.Player.BaseCharacterClass.ExperienceFactor + "%", 36, 45);
            SaveGame.Screen.Print(Colour.Black, "1d" + (race.HitDieBonus + SaveGame.Player.BaseCharacterClass.HitDieBonus), 37, 45);
            if (race.Infravision == 0)
            {
                SaveGame.Screen.Print(Colour.Black, "nil", 38, 45);
            }
            else
            {
                SaveGame.Screen.Print(Colour.Green, race.Infravision + "0 feet", 38, 45);
            }
            SaveGame.Screen.Print(Colour.Black, $"{race.BaseSearchBonus + SaveGame.Player.BaseCharacterClass.BaseSearchBonus:00}%", 39, 45);
            SaveGame.Screen.Print(Colour.Black, $"{race.BaseSearchFrequency + SaveGame.Player.BaseCharacterClass.BaseSearchFrequency:00}%", 40, 45);

            // Retrieve the description for the race and split the description into lines.
            string[] description = race.Description.Split("\n");

            // Render the description, center justified into row 32.
            int descriptionRow = 32 - (int)Math.Floor((double)description.Length / 2);
            foreach (string descriptionLine in description)
            {
                SaveGame.Screen.Print(Colour.Purple, descriptionLine, descriptionRow++, 21);
            }
        }
    }
}