// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class BirthStage : IGetKey
{
    protected readonly Game Game;
    public string GetKey => Key;
    protected BirthStage(Game game)
    {
        Game = game;
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

    public virtual void Bind() { }

    /// <summary>
    /// Renders the birth stage and returns the next birth stage to render or null when either the birth stage is complete or the Game.Shutdown is true.
    /// </summary>
    /// <returns></returns>
    public abstract BirthStage? Render();

    protected void DisplayPartialCharacter()
    {
        const string spaces = "                 ";
        Game.Screen.Clear(0);
        Game.Screen.Print(ColorEnum.Blue, "Name        :", 2, 1);
        Game.Screen.Print(ColorEnum.Brown, Game.PlayerName.StringValue ?? spaces, 2, 15);
        Game.Screen.Print(ColorEnum.Blue, "Gender      :", 3, 1);
        Game.Screen.Print(ColorEnum.Brown, Game.Gender?.Title ?? spaces, 3, 15);
        Game.Screen.Print(ColorEnum.Blue, "Race        :", 4, 1);
        Game.Screen.Print(ColorEnum.Brown, Game.Race?.Title ?? spaces, 4, 15);
        Game.Screen.Print(ColorEnum.Blue, "Class       :", 5, 1);
        Game.Screen.Print(ColorEnum.Brown, Game.BaseCharacterClass?.Title ?? spaces, 5, 15);
        if (Game.CanCastSpells)
        {
            Game.Screen.Print(ColorEnum.Blue, "Magic       :", 6, 1);
            Game.Screen.Print(ColorEnum.Brown, Game.RealmNames(Game.PrimaryRealm, Game.SecondaryRealm, spaces), 6, 15);
        }
        Game.Screen.Print(ColorEnum.Blue, "Birthday", 2, 32);
        Game.Screen.Print(ColorEnum.Blue, "Age          ", 3, 32);
        Game.Screen.Print(ColorEnum.Blue, "Height       ", 4, 32);
        Game.Screen.Print(ColorEnum.Blue, "Weight       ", 5, 32);
        Game.Screen.Print(ColorEnum.Blue, "Social Class ", 6, 32);
        Game.Screen.Print(ColorEnum.Blue, "STR:", 2 + AbilityEnum.Strength, 61);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 2 + AbilityEnum.Intelligence, 61);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 2 + AbilityEnum.Wisdom, 61);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 2 + AbilityEnum.Dexterity, 61);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 2 + AbilityEnum.Constitution, 61);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 2 + AbilityEnum.Charisma, 61);
        Game.Screen.Print(ColorEnum.Blue, "STR:", 14 + AbilityEnum.Strength, 1);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 14 + AbilityEnum.Intelligence, 1);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 14 + AbilityEnum.Wisdom, 1);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 14 + AbilityEnum.Dexterity, 1);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 14 + AbilityEnum.Constitution, 1);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 14 + AbilityEnum.Charisma, 1);
        Game.Screen.Print(ColorEnum.Blue, "STR:", 22 + AbilityEnum.Strength, 1);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 22 + AbilityEnum.Intelligence, 1);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 22 + AbilityEnum.Wisdom, 1);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 22 + AbilityEnum.Dexterity, 1);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 22 + AbilityEnum.Constitution, 1);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 22 + AbilityEnum.Charisma, 1);
        Game.Screen.Print(ColorEnum.Purple, "Initial", 21, 6);
        Game.Screen.Print(ColorEnum.Brown, "Race Class Mods", 21, 14);
        Game.Screen.Print(ColorEnum.Green, "Actual", 21, 30);
        Game.Screen.Print(ColorEnum.Red, "Reduced", 21, 37);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 21, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 22, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 23, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 24, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 25, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 26, 45);
        Game.Screen.Print(ColorEnum.Grey, "..............", 27, 45);
        Game.Screen.Print(ColorEnum.Blue, "Modifications", 28, 45);
        for (int i = 0; i < 6; i++)
        {
            string characterClassAbilityBonus = Game.BaseCharacterClass?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            Game.Screen.Print(ColorEnum.Brown, characterClassAbilityBonus, 22 + i, 20);
        }
        for (int i = 0; i < 6; i++)
        {
            string raceAbilityBonus = Game.Race?.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3) ?? "   ";
            Game.Screen.Print(ColorEnum.Brown, raceAbilityBonus, 22 + i, 14);
        }
    }

}
