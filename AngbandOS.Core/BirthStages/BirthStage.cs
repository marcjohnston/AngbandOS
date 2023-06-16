namespace AngbandOS.Core.BirthStages;

[Serializable]
internal abstract class BaseBirthStage
{
    protected readonly SaveGame SaveGame;
    protected BaseBirthStage(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Renders the birth stage and returns the next birth stage to render or null when either the birth stage is complete or the SaveGame.Shutdown is true.
    /// </summary>
    /// <returns></returns>
    public abstract BaseBirthStage? Render();

    protected void DisplayPartialCharacter()
    {
        const string spaces = "                 ";
        SaveGame.Screen.Clear(0);
        SaveGame.Screen.Print(Colour.Blue, "Name        :", 2, 1);
        SaveGame.Screen.Print(Colour.Brown, SaveGame.Player.Name ?? spaces, 2, 15);
        SaveGame.Screen.Print(Colour.Blue, "Gender      :", 3, 1);
        SaveGame.Screen.Print(Colour.Brown, SaveGame.Player.Gender?.Title ?? spaces, 3, 15);
        SaveGame.Screen.Print(Colour.Blue, "Race        :", 4, 1);
        SaveGame.Screen.Print(Colour.Brown, SaveGame.Player.Race?.Title ?? spaces, 4, 15);
        SaveGame.Screen.Print(Colour.Blue, "Class       :", 5, 1);
        SaveGame.Screen.Print(Colour.Brown, SaveGame.Player.BaseCharacterClass?.Title ?? spaces, 5, 15);
        if (SaveGame.Player.CanCastSpells)
        {
            SaveGame.Screen.Print(Colour.Blue, "Magic       :", 6, 1);
            SaveGame.Screen.Print(Colour.Brown, SaveGame.RealmNames(SaveGame.Player.PrimaryRealm, SaveGame.Player.SecondaryRealm, spaces), 6, 15);
        }
        SaveGame.Screen.Print(Colour.Blue, "Birthday", 2, 32);
        SaveGame.Screen.Print(Colour.Blue, "Age          ", 3, 32);
        SaveGame.Screen.Print(Colour.Blue, "Height       ", 4, 32);
        SaveGame.Screen.Print(Colour.Blue, "Weight       ", 5, 32);
        SaveGame.Screen.Print(Colour.Blue, "Social Class ", 6, 32);
        SaveGame.Screen.Print(Colour.Blue, "STR:", 2 + Ability.Strength, 61);
        SaveGame.Screen.Print(Colour.Blue, "INT:", 2 + Ability.Intelligence, 61);
        SaveGame.Screen.Print(Colour.Blue, "WIS:", 2 + Ability.Wisdom, 61);
        SaveGame.Screen.Print(Colour.Blue, "DEX:", 2 + Ability.Dexterity, 61);
        SaveGame.Screen.Print(Colour.Blue, "CON:", 2 + Ability.Constitution, 61);
        SaveGame.Screen.Print(Colour.Blue, "CHA:", 2 + Ability.Charisma, 61);
        SaveGame.Screen.Print(Colour.Blue, "STR:", 14 + Ability.Strength, 1);
        SaveGame.Screen.Print(Colour.Blue, "INT:", 14 + Ability.Intelligence, 1);
        SaveGame.Screen.Print(Colour.Blue, "WIS:", 14 + Ability.Wisdom, 1);
        SaveGame.Screen.Print(Colour.Blue, "DEX:", 14 + Ability.Dexterity, 1);
        SaveGame.Screen.Print(Colour.Blue, "CON:", 14 + Ability.Constitution, 1);
        SaveGame.Screen.Print(Colour.Blue, "CHA:", 14 + Ability.Charisma, 1);
        SaveGame.Screen.Print(Colour.Blue, "STR:", 22 + Ability.Strength, 1);
        SaveGame.Screen.Print(Colour.Blue, "INT:", 22 + Ability.Intelligence, 1);
        SaveGame.Screen.Print(Colour.Blue, "WIS:", 22 + Ability.Wisdom, 1);
        SaveGame.Screen.Print(Colour.Blue, "DEX:", 22 + Ability.Dexterity, 1);
        SaveGame.Screen.Print(Colour.Blue, "CON:", 22 + Ability.Constitution, 1);
        SaveGame.Screen.Print(Colour.Blue, "CHA:", 22 + Ability.Charisma, 1);
        SaveGame.Screen.Print(Colour.Purple, "Initial", 21, 6);
        SaveGame.Screen.Print(Colour.Brown, "Race Class Mods", 21, 14);
        SaveGame.Screen.Print(Colour.Green, "Actual", 21, 30);
        SaveGame.Screen.Print(Colour.Red, "Reduced", 21, 37);
        SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 21, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 22, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 23, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 24, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 25, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 26, 45);
        SaveGame.Screen.Print(Colour.Grey, "..............", 27, 45);
        SaveGame.Screen.Print(Colour.Blue, "Modifications", 28, 45);
        for (int i = 0; i < 6; i++)
        {
            string characterClassAbilityBonus = SaveGame.Player.BaseCharacterClass?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            SaveGame.Screen.Print(Colour.Brown, characterClassAbilityBonus, 22 + i, 20);
        }
        for (int i = 0; i < 6; i++)
        {
            string raceAbilityBonus = SaveGame.Player.Race?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            SaveGame.Screen.Print(Colour.Brown, raceAbilityBonus, 22 + i, 14);
        }
    }

}
