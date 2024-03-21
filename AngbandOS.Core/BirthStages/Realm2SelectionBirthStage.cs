// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class Realm2SelectionBirthStage : BirthStage
{
    private int currentSelection = 0;
    private Realm2SelectionBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = Game.BaseCharacterClass.AvailableSecondaryRealms
            .Where(_realm => _realm != Game.PrimaryRealm)
            .Select(_realm => _realm.Name)
            .ToArray(); ;
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
        Realm[] remainingRealms = Game.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != Game.PrimaryRealm).ToArray();
        Realm realm = remainingRealms[index];
        Game.DisplayRealmInfo(realm);
        return true;
    }
    private BirthStage? GoForward(int index)
    {
        Realm[] remainingRealms = Game.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != Game.PrimaryRealm).ToArray();
        Game.SecondaryRealm = remainingRealms[index];
        Game.God = Game.BaseCharacterClass.DefaultDeity(Game.SecondaryRealm);
        return Game.SingletonRepository.BirthStages.Get(nameof(GenderSelectionBirthStage));
    }

    private BirthStage? GoBack()
    {
        int availablePrimaryRealmCount = Game.BaseCharacterClass.AvailablePrimaryRealms.Length;
        if (availablePrimaryRealmCount <= 1)
        {
            return Game.SingletonRepository.BirthStages.Get(nameof(RaceSelectionBirthStage));
        }
        return Game.SingletonRepository.BirthStages.Get(nameof(Realm1SelectionBirthStage));
    }
}