// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class RaceSelectionBirthStage : BirthStage
{
    private int currentSelection = 16;
    private RaceSelectionBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = Game.SingletonRepository.Get<Race>()
            .OrderBy((Race race) => race.Title)
            .Select((Race race) => race.Title)
            .ToArray(); ;
        Game.Screen.Print(ColorEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
        while (!Game.Shutdown)
        {
            Game.MenuDisplay(currentSelection, menuItems);
            RenderSelection(currentSelection);
            char c = Game.Inkey();
            switch (c)
            {
                case '8':
                    if (currentSelection > 0)
                    {
                        currentSelection--;
                    }
                    break;
                case '2':
                    if (currentSelection < menuItems.Length - 1)
                    {
                        currentSelection++;
                    }
                    break;
                case '6':
                    return GoForward(currentSelection);
                case '4':
                    return GoBack();
                case 'h':
                    Game.ShowManual();
                    break;
            }
        }
        return null;
    }

    private bool RenderSelection(int index)
    {
        Race[] races = Game.SingletonRepository.Get<Race>()
            .OrderBy((Race race) => race.Title)
            .ToArray();
        Race race = races[index];

        Game.Screen.Print(ColorEnum.Purple, "STR:", 36, 21);
        Game.Screen.Print(ColorEnum.Purple, "INT:", 37, 21);
        Game.Screen.Print(ColorEnum.Purple, "WIS:", 38, 21);
        Game.Screen.Print(ColorEnum.Purple, "DEX:", 39, 21);
        Game.Screen.Print(ColorEnum.Purple, "CON:", 40, 21);
        Game.Screen.Print(ColorEnum.Purple, "CHA:", 41, 21);
        int i = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(race, ability));
            string compositeKey = CharacterClassAbility.GetCompositeKey(Game.CharacterClass, ability);
            CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);
            int bonus = raceAbility.Bonus + characterClassAbility.Bonus;
            Game.DisplayStatBonus(26, 36 + i, bonus);
            i++;
        }
        Game.Screen.Print(ColorEnum.Purple, "Disarming   :", 36, 53);
        Game.Screen.Print(ColorEnum.Purple, "Magic Device:", 37, 53);
        Game.Screen.Print(ColorEnum.Purple, "Saving Throw:", 38, 53);
        Game.Screen.Print(ColorEnum.Purple, "Stealth     :", 39, 53);
        Game.Screen.Print(ColorEnum.Purple, "Fighting    :", 40, 53);
        Game.Screen.Print(ColorEnum.Purple, "Shooting    :", 41, 53);
        Game.Screen.Print(ColorEnum.Purple, "Experience  :", 36, 31);
        Game.Screen.Print(ColorEnum.Purple, "Hit Dice    :", 37, 31);
        Game.Screen.Print(ColorEnum.Purple, "Infravision :", 38, 31);
        Game.Screen.Print(ColorEnum.Purple, "Searching   :", 39, 31);
        Game.Screen.Print(ColorEnum.Purple, "Perception  :", 40, 31);
        Game.DisplayAPlusB(67, 36, Game.CharacterClass.EffectiveAttributeSet.Get<ReadOnlyAttributeValue<int>>(nameof(DisarmTrapsAttribute)).Value + race.EffectiveAttributeSet.Get<ReadOnlyAttributeValue<int>>(nameof(DisarmTrapsAttribute)).Value, Game.CharacterClass.DisarmBonusPerLevel);
        Game.DisplayAPlusB(67, 37, Game.CharacterClass.UseDevice + race.UseDevice, Game.CharacterClass.DeviceBonusPerLevel);
        Game.DisplayAPlusB(67, 38, Game.CharacterClass.SavingThrow + race.SavingThrow, Game.CharacterClass.SaveBonusPerLevel);
        Game.DisplayAPlusB(67, 39, (Game.CharacterClass.Stealth * 4) + (race.Stealth * 4), Game.CharacterClass.StealthBonusPerLevel * 4);
        Game.DisplayAPlusB(67, 40, Game.CharacterClass.MeleeToHit + race.MeleeToHit, Game.CharacterClass.MeleeAttackBonusPerLevel);
        Game.DisplayAPlusB(67, 41, Game.CharacterClass.RangedToHit + race.RangedToHit, Game.CharacterClass.RangedAttackBonusPerLevel);
        Game.Screen.Print(ColorEnum.Black, race.ExperienceFactor + Game.CharacterClass.ExperienceFactor + "%", 36, 45);
        Game.Screen.Print(ColorEnum.Black, "1d" + (race.HitDieBonus + Game.CharacterClass.HitDieBonus), 37, 45);
        int bonusInfravision = race.EffectiveAttributeSet.Get<ReadOnlyAttributeValue<int>>(nameof(InfravisionAttribute)).Value;
        if (bonusInfravision == 0)
        {
            Game.Screen.Print(ColorEnum.Black, "nil", 38, 45);
        }
        else
        {
            Game.Screen.Print(ColorEnum.Green, bonusInfravision + "0 feet", 38, 45); // TODO: This assumes a 10 foot per unit of infravision conversion that should be configurable.
        }
        Game.Screen.Print(ColorEnum.Black, $"{race.Search + Game.CharacterClass.Search:00}%", 39, 45);
        Game.Screen.Print(ColorEnum.Black, $"{race.BaseSearchFrequency + Game.CharacterClass.BaseSearchFrequency:00}%", 40, 45);

        // Retrieve the description for the race and split the description into lines.
        string[] description = race.Description.Split("\n");

        // Render the description, center justified into row 32.
        int descriptionRow = 32 - (int)Math.Floor((double)description.Length / 2);
        foreach (string descriptionLine in description)
        {
            Game.Screen.Print(ColorEnum.Purple, descriptionLine, descriptionRow++, 21);
        }
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        Race[] races = Game.SingletonRepository.Get<Race>()
            .OrderBy((Race race) => race.Title)
            .ToArray();
        Game.Race = races[index];
        Game.GetFirstLevelMutation = Game.Race.AutomaticallyGainsFirstLevelMutationAtBirth;

        // Check to see how many realms the player can study.
        int availablePrimaryRealmCount = Game.CharacterClass.AvailablePrimaryRealms.Length;
        Realm[] remainingAvailableSecondaryRealms = Game.CharacterClass.RemainingAvailableSecondaryRealms();
        int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
        if (availablePrimaryRealmCount == 0)
        {
            // The player cannot study any realms.
            Game.PrimaryRealm = null;
            Game.SecondaryRealm = null;
            return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
        }
        else if (availablePrimaryRealmCount == 1)
        {
            // There is only one realm, auto select it.
            Game.PrimaryRealm = Game.CharacterClass.AvailablePrimaryRealms[0];

            // Check the secondary realm selection.
            if (remainingAvailableSecondaryRealmCount == 0)
            {
                Game.SecondaryRealm = null;
                return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
            }
            else if (remainingAvailableSecondaryRealmCount == 1)
            {
                // There is only one realm, auto select it.
                Game.SecondaryRealm = remainingAvailableSecondaryRealms[0];
                return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
            }
            else
            {
                return Game.SingletonRepository.Get<BirthStage>(nameof(Realm2SelectionBirthStage));
            }
        }

        return Game.SingletonRepository.Get<BirthStage>(nameof(Realm1SelectionBirthStage));
    }

    private BirthStage? GoBack()
    {
        return Game.SingletonRepository.Get<BirthStage>(nameof(ClassSelectionBirthStage));
    }
}