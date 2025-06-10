// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class Realm1SelectionBirthStage : BirthStage
{
    private int currentSelection = 0;
    private Realm1SelectionBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = Game.BaseCharacterClass.AvailablePrimaryRealms
            .Select(_availablePrimaryRealms => _availablePrimaryRealms.Name)
            .ToArray();
        Game.Screen.Print(ColorEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);

        // The index might be out of range if the user switches between classes.
        if (currentSelection >= Game.BaseCharacterClass.AvailablePrimaryRealms.Length)
        {
            currentSelection = Game.BaseCharacterClass.AvailablePrimaryRealms.Length - 1;
        }

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
        Realm realm = Game.BaseCharacterClass.AvailablePrimaryRealms[index];
        Game.DisplayRealmInfo(realm);
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        Realm realm = Game.BaseCharacterClass.AvailablePrimaryRealms[index];
        Game.PrimaryRealm = realm;
        Realm[] remainingAvailableSecondaryRealms = Game.BaseCharacterClass.RemainingAvailableSecondaryRealms();
        int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
        if (remainingAvailableSecondaryRealmCount == 0)
        {
            Game.SecondaryRealm = null;
            return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
        }
        else if (remainingAvailableSecondaryRealmCount == 1)
        {
            Game.SecondaryRealm = remainingAvailableSecondaryRealms[0];
            return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
        }
        return Game.SingletonRepository.Get<BirthStage>(nameof(Realm2SelectionBirthStage));
    }

    private BirthStage? GoBack()
    {
        return Game.SingletonRepository.Get<BirthStage>(nameof(RaceSelectionBirthStage));
    }
}