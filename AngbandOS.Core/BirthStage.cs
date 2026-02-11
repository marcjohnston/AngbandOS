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

    public virtual string Key => GetType().Name;

    public void Bind() { }

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
        Game.Screen.Print(ColorEnum.Brown, Game.CharacterClass?.Title ?? spaces, 5, 15);
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
        Game.Screen.Print(ColorEnum.Blue, "STR:", 2, 61);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 3, 61);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 4, 61);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 5, 61);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 6, 61);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 7, 61);
        Game.Screen.Print(ColorEnum.Blue, "STR:", 14, 1);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 15, 1);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 16, 1);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 17, 1);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 18, 1);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 19, 1);
        Game.Screen.Print(ColorEnum.Blue, "STR:", 22, 1);
        Game.Screen.Print(ColorEnum.Blue, "INT:", 23, 1);
        Game.Screen.Print(ColorEnum.Blue, "WIS:", 24, 1);
        Game.Screen.Print(ColorEnum.Blue, "DEX:", 25, 1);
        Game.Screen.Print(ColorEnum.Blue, "CON:", 26, 1);
        Game.Screen.Print(ColorEnum.Blue, "CHA:", 27, 1);
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
        if (Game.CharacterClass is not null)
        {
            int i = 0;
            foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
            {
                string compositeKey = CharacterClassAbility.GetCompositeKey(Game.CharacterClass, ability);
                CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);
                string characterClassAbilityBonus = characterClassAbility.Bonus.ToString("+0;-0;+0").PadLeft(3) ?? "   ";
                Game.Screen.Print(ColorEnum.Brown, characterClassAbilityBonus, 22 + i, 20);
                i++;
            }
        }
        if (Game.Race is not null)
        {
            int i = 0;
            foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
            {
                RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Game.Race, ability));
                string raceAbilityBonus = raceAbility.Bonus.ToString("+0;-0;+0").PadLeft(3) ?? "   ";
                Game.Screen.Print(ColorEnum.Brown, raceAbilityBonus, 22 + i, 14);
                i++;
            }
         }
    }

}
