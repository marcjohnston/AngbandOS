// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class Realm2SelectionBirthStage : BaseBirthStage
{
    private int currentSelection = 0;
    private Realm2SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
    public override BaseBirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = SaveGame.BaseCharacterClass.AvailableSecondaryRealms
            .Where(_realm => _realm != SaveGame.PrimaryRealm)
            .Select(_realm => _realm.Name)
            .ToArray(); ;
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
        BaseRealm[] remainingRealms = SaveGame.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.PrimaryRealm).ToArray();
        BaseRealm realm = remainingRealms[index];
        SaveGame.DisplayRealmInfo(realm);
        return true;
    }
    private BaseBirthStage? GoForward(int index)
    {
        BaseRealm[] remainingRealms = SaveGame.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.PrimaryRealm).ToArray();
        SaveGame.SecondaryRealm = remainingRealms[index];
        SaveGame.Religion.Deity = SaveGame.BaseCharacterClass.DefaultDeity(SaveGame.SecondaryRealm);
        return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
    }

    private BaseBirthStage? GoBack()
    {
        int availablePrimaryRealmCount = SaveGame.BaseCharacterClass.AvailablePrimaryRealms.Length;
        if (availablePrimaryRealmCount <= 1)
        {
            return SaveGame.SingletonRepository.BirthStages.Get<RaceSelectionBirthStage>();
        }
        return SaveGame.SingletonRepository.BirthStages.Get<Realm1SelectionBirthStage>();
    }
}