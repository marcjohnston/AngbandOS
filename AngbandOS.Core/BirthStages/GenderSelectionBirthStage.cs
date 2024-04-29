// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class GenderSelectionBirthStage : BirthStage
{
    private int currentSelection = 0;
    private GenderSelectionBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = Game.SingletonRepository.Get<Gender>()
            .Select(_gender => _gender.Title)
            .ToArray();
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
        Game.Screen.Print(ColorEnum.Purple, "Your sex has no effect on gameplay.", 35, 21);
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        Game.Gender = Game.SingletonRepository.Get<Gender>(index);
        return Game.SingletonRepository.Get<BirthStage>(nameof(ConfirmationBirthStage));
    }

    private BirthStage? GoBack()
    {
        int availablePrimaryRealmCount = Game.BaseCharacterClass.AvailablePrimaryRealms.Length;
        int remainingAvailableSecondaryRealmCount = Game.BaseCharacterClass.RemainingAvailableSecondaryRealms().Length;
        if (remainingAvailableSecondaryRealmCount <= 1 && availablePrimaryRealmCount <= 1)
        {
            return Game.SingletonRepository.Get<BirthStage>(nameof(RaceSelectionBirthStage));
        }
        else if (remainingAvailableSecondaryRealmCount <= 1)
        {
            return Game.SingletonRepository.Get<BirthStage>(nameof(Realm1SelectionBirthStage));
        }
        return Game.SingletonRepository.Get<BirthStage>(nameof(Realm2SelectionBirthStage));
    }
}