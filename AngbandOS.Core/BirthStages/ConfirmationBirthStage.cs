namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class ConfirmationBirthStage : BaseBirthStage
    {
        private ConfirmationBirthStage(SaveGame saveGame) : base(saveGame) { }

        public override string[]? GetMenu()
        {
            return null;
        }

        public override bool RenderSelection(int index)
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
            return true;
        }

        public override int? GoForward(int index)
        {
            return BirthStage.Naming;
        }

        public override int? GoBack()
        {
            return BirthStage.GenderSelection;
        }
    }
}
