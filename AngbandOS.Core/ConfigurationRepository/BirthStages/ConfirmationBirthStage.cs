﻿// AngbandOS: 2022 Marc Johnston
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

        SaveGame.Spells[0] = SaveGame.PrimaryRealm == null ? new Spell[] { } : SaveGame.PrimaryRealm.SpellList(SaveGame.BaseCharacterClass);
        SaveGame.Spells[1] = SaveGame.SecondaryRealm == null ? new Spell[] { } : SaveGame.SecondaryRealm.SpellList(SaveGame.BaseCharacterClass);
        SaveGame.Talents = new List<Talent>();
        foreach (Talent talent in SaveGame.SingletonRepository.Talents)
        {
            SaveGame.Talents.Add(talent);
            talent.Initialize(SaveGame.BaseCharacterClass.ID);
        }
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

        SaveGame.GooPatron = SaveGame.SingletonRepository.Patrons.ToWeightedRandom().Choose();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateHealthFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateBonusesFlaggedAction>().Set();
        SaveGame.UpdateStuff();
        SaveGame.Health = SaveGame.MaxHealth;
        SaveGame.Mana = SaveGame.MaxMana;
        SaveGame.Energy = 150;
        while (!SaveGame.Shutdown)
        {
            SaveGame.Screen.Print(ColourEnum.Orange, "[Use return to confirm, or left to go back.]", 43, 1);
            RenderCharacterScript showCharacterSheet = SaveGame.SingletonRepository.Scripts.Get<RenderCharacterScript>();
            showCharacterSheet.Execute();
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