// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class ConfirmationBirthStage : BirthStage
{
    private ConfirmationBirthStage(SaveGame saveGame) : base(saveGame) { }

    public override BirthStage? Render()
    {
        SaveGame.GetStats();
        SaveGame.GetExtra();
        SaveGame.GetAhw();
        SaveGame.GetHistory();
        SaveGame.GetMoney();

        SaveGame.Talents = new List<Talent>();
        foreach (Talent talent in SaveGame.SingletonRepository.Talents)
        {
            SaveGame.Talents.Add(talent);
        }
        if (SaveGame.PrimaryRealm != null)
        {
            SaveGame.PrimaryRealm.InitializeSpells();

            if (SaveGame.SecondaryRealm != null)
            {
                SaveGame.SecondaryRealm.InitializeSpells();
            }
        }

        SaveGame.SpellOrder.Clear();

        SaveGame.GooPatron = SaveGame.SingletonRepository.Patrons.ToWeightedRandom().ChooseOrDefault();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.UpdateStuff();
        SaveGame.Health = SaveGame.MaxHealth;
        SaveGame.Mana = SaveGame.MaxMana;
        SaveGame.Energy = 150;
        while (!SaveGame.Shutdown)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "[Use return to confirm, or left to go back.]", 43, 1);
            RenderCharacterScript showCharacterSheet = (RenderCharacterScript)SaveGame.SingletonRepository.Scripts.Get(nameof(RenderCharacterScript));
            showCharacterSheet.ExecuteScript();
            char c = SaveGame.Inkey();
            switch (c)
            {
                case (char)13:
                    return SaveGame.SingletonRepository.BirthStages.Get(nameof(NamingBirthStage));
                case '4':
                    return SaveGame.SingletonRepository.BirthStages.Get(nameof(GenderSelectionBirthStage));
                case 'h':
                    SaveGame.ShowManual();
                    break;
            }
        }
        return null;
    }
}
