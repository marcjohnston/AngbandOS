// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class GenderSelectionBirthStage : BaseBirthStage
{
    private int currentSelection = 0;
    private GenderSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
    public override BaseBirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = SaveGame.SingletonRepository.Genders
            .Select(_gender => _gender.Title)
            .ToArray();
        SaveGame.Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
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
        SaveGame.Screen.Print(Colour.Purple, "Your sex has no effect on gameplay.", 35, 21);
        return true;
    }
    private BaseBirthStage? GoForward(int index)
    {
        SaveGame.Player.Gender = SaveGame.SingletonRepository.Genders[index];
        return SaveGame.SingletonRepository.BirthStages.Get<ConfirmationBirthStage>();
    }

    private BaseBirthStage? GoBack()
    {
        int availablePrimaryRealmCount = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms.Length;
        int remainingAvailableSecondaryRealmCount = SaveGame.Player.BaseCharacterClass.RemainingAvailableSecondaryRealms().Length;
        if (remainingAvailableSecondaryRealmCount <= 1 && availablePrimaryRealmCount <= 1)
        {
            return SaveGame.SingletonRepository.BirthStages.Get<RaceSelectionBirthStage>();
        }
        else if (remainingAvailableSecondaryRealmCount <= 1)
        {
            return SaveGame.SingletonRepository.BirthStages.Get<Realm1SelectionBirthStage>();
        }
        return SaveGame.SingletonRepository.BirthStages.Get<Realm2SelectionBirthStage>();
    }
}