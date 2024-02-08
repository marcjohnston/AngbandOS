// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal abstract class BirthStage : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    public string GetKey => Key;
    protected BirthStage(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public void Bind() { }

    /// <summary>
    /// Renders the birth stage and returns the next birth stage to render or null when either the birth stage is complete or the SaveGame.Shutdown is true.
    /// </summary>
    /// <returns></returns>
    public abstract BirthStage? Render();

    protected void DisplayPartialCharacter()
    {
        const string spaces = "                 ";
        SaveGame.Screen.Clear(0);
        SaveGame.Screen.Print(ColorEnum.Blue, "Name        :", 2, 1);
        SaveGame.Screen.Print(ColorEnum.Brown, SaveGame.Name ?? spaces, 2, 15);
        SaveGame.Screen.Print(ColorEnum.Blue, "Gender      :", 3, 1);
        SaveGame.Screen.Print(ColorEnum.Brown, SaveGame.Gender?.Title ?? spaces, 3, 15);
        SaveGame.Screen.Print(ColorEnum.Blue, "Race        :", 4, 1);
        SaveGame.Screen.Print(ColorEnum.Brown, SaveGame.Race?.Title ?? spaces, 4, 15);
        SaveGame.Screen.Print(ColorEnum.Blue, "Class       :", 5, 1);
        SaveGame.Screen.Print(ColorEnum.Brown, SaveGame.BaseCharacterClass?.Title ?? spaces, 5, 15);
        if (SaveGame.CanCastSpells)
        {
            SaveGame.Screen.Print(ColorEnum.Blue, "Magic       :", 6, 1);
            SaveGame.Screen.Print(ColorEnum.Brown, SaveGame.RealmNames(SaveGame.PrimaryRealm, SaveGame.SecondaryRealm, spaces), 6, 15);
        }
        SaveGame.Screen.Print(ColorEnum.Blue, "Birthday", 2, 32);
        SaveGame.Screen.Print(ColorEnum.Blue, "Age          ", 3, 32);
        SaveGame.Screen.Print(ColorEnum.Blue, "Height       ", 4, 32);
        SaveGame.Screen.Print(ColorEnum.Blue, "Weight       ", 5, 32);
        SaveGame.Screen.Print(ColorEnum.Blue, "Social Class ", 6, 32);
        SaveGame.Screen.Print(ColorEnum.Blue, "STR:", 2 + Ability.Strength, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "INT:", 2 + Ability.Intelligence, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "WIS:", 2 + Ability.Wisdom, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "DEX:", 2 + Ability.Dexterity, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "CON:", 2 + Ability.Constitution, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "CHA:", 2 + Ability.Charisma, 61);
        SaveGame.Screen.Print(ColorEnum.Blue, "STR:", 14 + Ability.Strength, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "INT:", 14 + Ability.Intelligence, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "WIS:", 14 + Ability.Wisdom, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "DEX:", 14 + Ability.Dexterity, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "CON:", 14 + Ability.Constitution, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "CHA:", 14 + Ability.Charisma, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "STR:", 22 + Ability.Strength, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "INT:", 22 + Ability.Intelligence, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "WIS:", 22 + Ability.Wisdom, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "DEX:", 22 + Ability.Dexterity, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "CON:", 22 + Ability.Constitution, 1);
        SaveGame.Screen.Print(ColorEnum.Blue, "CHA:", 22 + Ability.Charisma, 1);
        SaveGame.Screen.Print(ColorEnum.Purple, "Initial", 21, 6);
        SaveGame.Screen.Print(ColorEnum.Brown, "Race Class Mods", 21, 14);
        SaveGame.Screen.Print(ColorEnum.Green, "Actual", 21, 30);
        SaveGame.Screen.Print(ColorEnum.Red, "Reduced", 21, 37);
        SaveGame.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 21, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 22, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 23, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 24, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 25, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 26, 45);
        SaveGame.Screen.Print(ColorEnum.Grey, "..............", 27, 45);
        SaveGame.Screen.Print(ColorEnum.Blue, "Modifications", 28, 45);
        for (int i = 0; i < 6; i++)
        {
            string characterClassAbilityBonus = SaveGame.BaseCharacterClass?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            SaveGame.Screen.Print(ColorEnum.Brown, characterClassAbilityBonus, 22 + i, 20);
        }
        for (int i = 0; i < 6; i++)
        {
            string raceAbilityBonus = SaveGame.Race?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            SaveGame.Screen.Print(ColorEnum.Brown, raceAbilityBonus, 22 + i, 14);
        }
    }

}
