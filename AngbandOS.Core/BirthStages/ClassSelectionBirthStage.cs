// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class ClassSelectionBirthStage : BirthStage
{
    private int currentSelection = 14;
    private ClassSelectionBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = Game.SingletonRepository.Get<BaseCharacterClass>()
            .OrderBy(_characterClass => _characterClass.Title)
            .Select(_characterClass => _characterClass.Title)
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

    /// <summary>
    /// Renders the details of a Character Class during the Birth selection process.
    /// </summary>
    /// <param name="characterClass"></param>

    private bool RenderSelection(int index)
    {
        BaseCharacterClass[] classes = Game.SingletonRepository.Get<BaseCharacterClass>()
            .OrderBy(_characterClass => _characterClass.Title)
            .ToArray();

        BaseCharacterClass characterClass = classes[index];
        Game.Screen.Print(ColorEnum.Purple, "STR:", 36, 21);
        Game.Screen.Print(ColorEnum.Purple, "INT:", 37, 21);
        Game.Screen.Print(ColorEnum.Purple, "WIS:", 38, 21);
        Game.Screen.Print(ColorEnum.Purple, "DEX:", 39, 21);
        Game.Screen.Print(ColorEnum.Purple, "CON:", 40, 21);
        Game.Screen.Print(ColorEnum.Purple, "CHA:", 41, 21);
        int i = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            string compositeKey = CharacterClassAbility.GetCompositeKey(characterClass, ability);
            CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);

            int bonus = characterClassAbility.Bonus;
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
        Game.DisplayAPlusB(67, 36, characterClass.EffectiveAttributeSet.GetValue<IntAttributeValue>(AttributeEnum.DisarmTraps).Value, characterClass.DisarmBonusPerLevel);
        Game.DisplayAPlusB(67, 37, characterClass.UseDevice, characterClass.DeviceBonusPerLevel);
        Game.DisplayAPlusB(67, 38, characterClass.SavingThrow, characterClass.SaveBonusPerLevel);
        Game.DisplayAPlusB(67, 39, characterClass.Stealth * 4, characterClass.StealthBonusPerLevel * 4);
        Game.DisplayAPlusB(67, 40, characterClass.MeleeToHit, characterClass.MeleeAttackBonusPerLevel);
        Game.DisplayAPlusB(67, 41, characterClass.RangedToHit, characterClass.RangedAttackBonusPerLevel);
        string buf = "+" + characterClass.ExperienceFactor + "%";
        Game.Screen.Print(ColorEnum.Black, buf, 36, 45);
        buf = "1d" + characterClass.HitDieBonus;
        Game.Screen.Print(ColorEnum.Black, buf, 37, 45);
        Game.Screen.Print(ColorEnum.Black, "-", 38, 45);
        buf = $"{characterClass.Search:00}%";
        Game.Screen.Print(ColorEnum.Black, buf, 39, 45);
        buf = $"{characterClass.BaseSearchFrequency:00}%";
        Game.Screen.Print(ColorEnum.Black, buf, 40, 45);

        int y = 30;
        foreach (string classInfo in characterClass.Info)
        {
            Game.Screen.Print(ColorEnum.Purple, classInfo, y, 20);
            y++;
        }
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        BaseCharacterClass[] classes = Game.SingletonRepository.Get<BaseCharacterClass>()
            .OrderBy(_characterClass => _characterClass.Title)
            .ToArray();

        Game.BaseCharacterClass = classes[index];
        return Game.SingletonRepository.Get<BirthStage>(nameof(RaceSelectionBirthStage));
    }

    private BirthStage? GoBack()
    {
        return Game.SingletonRepository.Get<BirthStage>(nameof(IntroductionBirthStage));
    }
}