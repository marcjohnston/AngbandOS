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
    private Realm1SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = SaveGame.BaseCharacterClass.AvailablePrimaryRealms
            .Select(_availablePrimaryRealms => _availablePrimaryRealms.Name)
            .ToArray();
        SaveGame.Screen.Print(ColourEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);

        // The index might be out of range if the user switches between classes.
        if (currentSelection >= SaveGame.BaseCharacterClass.AvailablePrimaryRealms.Length)
        {
            currentSelection = SaveGame.BaseCharacterClass.AvailablePrimaryRealms.Length - 1;
        }

        while (!SaveGame.Shutdown)
        {
            SaveGame.MenuDisplay(currentSelection, menuItems);
            RenderSelection(currentSelection);
            char c = SaveGame.Inkey();
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
                    SaveGame.ShowManual();
                    break;
            }
        }
        return null;
    }
    private bool RenderSelection(int index)
    {
        BaseRealm realm = SaveGame.BaseCharacterClass.AvailablePrimaryRealms[index];
        SaveGame.DisplayRealmInfo(realm);
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        BaseRealm realm = SaveGame.BaseCharacterClass.AvailablePrimaryRealms[index];
        SaveGame.PrimaryRealm = realm;
        BaseRealm[] remainingAvailableSecondaryRealms = SaveGame.BaseCharacterClass.RemainingAvailableSecondaryRealms();
        int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
        if (remainingAvailableSecondaryRealmCount == 0)
        {
            SaveGame.SecondaryRealm = null;
            return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
        }
        else if (remainingAvailableSecondaryRealmCount == 1)
        {
            SaveGame.SecondaryRealm = remainingAvailableSecondaryRealms[0];
            return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
        }
        return SaveGame.SingletonRepository.BirthStages.Get<Realm2SelectionBirthStage>();
    }

    private BirthStage? GoBack()
    {
        return SaveGame.SingletonRepository.BirthStages.Get<RaceSelectionBirthStage>();
    }
}