namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class ConfirmationBirthStage : BaseBirthStage
{
    private ConfirmationBirthStage(SaveGame saveGame) : base(saveGame) { }

    public override BaseBirthStage? Render()
    {
        SaveGame.GetStats();
        SaveGame.GetExtra();
        SaveGame.GetAhw();
        SaveGame.GetHistory(SaveGame.Player);
        SaveGame.GetMoney();

        SaveGame.Spells[0] = SaveGame.Player.PrimaryRealm == null ? new Spell[] { } : SaveGame.Player.PrimaryRealm.SpellList(SaveGame.Player.BaseCharacterClass);
        SaveGame.Spells[1] = SaveGame.Player.SecondaryRealm == null ? new Spell[] { } : SaveGame.Player.SecondaryRealm.SpellList(SaveGame.Player.BaseCharacterClass);
        SaveGame.Talents = new TalentList(SaveGame.Player.BaseCharacterClass.ID);
        SaveGame.SpellFirst = 100;
        foreach (Spell[] bookset in SaveGame.Spells)
        {
            foreach (Spell spell in bookset)
            {
                if (spell.Level < SaveGame.SpellFirst)
                {
                    SaveGame.SpellFirst = spell.Level;
                }
            }
        }
        SaveGame.SpellOrder.Clear();

        SaveGame.Player.GooPatron = SaveGame.SingletonRepository.Patrons.ToWeightedRandom().Choose();
        SaveGame.UpdateHealthFlaggedAction.Set();
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.UpdateStuff();
        SaveGame.Player.Health = SaveGame.Player.MaxHealth;
        SaveGame.Player.Mana = SaveGame.Player.MaxMana;
        SaveGame.Player.Energy = 150;
        while (!SaveGame.Shutdown)
        {
            SaveGame.Screen.Print(Colour.Orange, "[Use return to confirm, or left to go back.]", 43, 1);
            SaveGame.DisplayPlayer();
            char c = SaveGame.Inkey();
            switch (c)
            {
                case (char)13:
                    return SaveGame.SingletonRepository.BirthStages.Get<NamingBirthStage>();
                case '4':
                    return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
                case 'h':
                    SaveGame.ShowManual();
                    break;
            }
        }
        return null;
    }
}
