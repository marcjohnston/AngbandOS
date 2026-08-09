// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.BirthStages;

internal class ConfirmationBirthStage : BirthStage
{
    private ConfirmationBirthStage(Game game) : base(game) { }

    private void AdjustAbility(Ability ability, int bonus)
    {
        ability.Adjusted = ability.ModifyStatValue(ability.InnateMax, bonus);
    }
    private void GetStats()
    {
        InnateTotals innateTotals = Game.GetInnateTotals(Game.CharacterClass, Game.Race);

        while (true)
        {
            // Assign the innate max stats to each of the abilities. The max stats are randomly assigned to each ability, but the total of the max stats is always the same.
            List<int> maxList = new List<int>(innateTotals.MaxInnates);
            foreach (Ability ability in Game.SingletonRepository.Get<Ability>()) // There are six abilities
            {
                int maxIndex = Game.RandomLessThan(maxList.Count); // Choose a random max from the maxList
                int max = maxList[maxIndex];
                maxList.RemoveAt(maxIndex);
                ability.InnateMax = max;

                // Assign the current innate value to the max value.
                ability.Innate = ability.InnateMax;
            }

            // Adjust each ability with the race and character class bonuses. The bonuses are applied to the innate max value to get the adjusted value.
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(CharismaAbility)), Game.Race.AttributeSet.GetInt(nameof(CharismaAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusCharismaAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusCharismaAttribute)));
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(ConstitutionAbility)), Game.Race.AttributeSet.GetInt(nameof(ConstitutionAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusConstitutionAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusCharismaAttribute)));
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)), Game.Race.AttributeSet.GetInt(nameof(DexterityAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusDexterityAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusCharismaAttribute)));
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)), Game.Race.AttributeSet.GetInt(nameof(IntelligenceAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusIntelligenceAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusIntelligenceAttribute)));
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)), Game.Race.AttributeSet.GetInt(nameof(StrengthAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusStrengthAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusStrengthAttribute)));
            AdjustAbility(Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility)), Game.Race.AttributeSet.GetInt(nameof(WisdomAbility)) + Game.CharacterClass.AttributeSet.GetInt(nameof(BonusWisdomAttribute)) + Game.Race.AttributeSet.GetInt(nameof(BonusWisdomAttribute)));

            // The prime stat must be least 14, otherwise we need to reroll the stats. This is a requirement for the game to be playable.
            if (Game.CharacterClass.PrimeStat.InnateMax >= 14)
            {
                break;
            }
        }
    }

    public override BirthStage? Render()
    {
        GetStats();
        Game.GetExtra();
        Game.GetAhw();
        Game.GetHistory();
        Game.GetStartingGold();
        Game.RefreshGods();

        if (Game.PrimaryRealm != null)
        {
            Game.PrimaryRealm.InitializeSpells();
            Game.LevelOfFirstSpell = Game.PrimaryRealm.FirstSpellLevel;

            if (Game.SecondaryRealm != null)
            {
                Game.SecondaryRealm.InitializeSpells();
                if (Game.LevelOfFirstSpell == null)
                {
                    Game.LevelOfFirstSpell = Game.SecondaryRealm.FirstSpellLevel;
                }
                else if (Game.SecondaryRealm.FirstSpellLevel != null)
                {
                    Game.LevelOfFirstSpell = Math.Min(Game.LevelOfFirstSpell.Value, Game.SecondaryRealm.FirstSpellLevel.Value);
                }
            }
        }

        Game.SpellOrder.Clear();

        Game.GooPatron = Game.SingletonRepository.ToWeightedRandom<Patron>().ChooseOrDefault();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.UpdateStuff();
        Game.Health.IntValue = Game.MaxHealth.IntValue;
        Game.Mana.IntValue = Game.MaxMana.IntValue;
        Game.Energy = 150;
        while (!Game.Shutdown)
        {
            Game.Screen.Print(ColorEnum.Orange, "[Use return to confirm, or left to go back.]", 43, 1);
            IScript showCharacterSheet = Game.SingletonRepository.Get<IScript>(nameof(RenderCharacterScript)); // TODO: This framework object uses a gamepack script
            showCharacterSheet.ExecuteScript();
            char c = Game.GetAndRecordKeystroke();
            switch (c)
            {
                case (char)13:
                    return Game.SingletonRepository.Get<BirthStage>(nameof(NamingBirthStage));
                case '4':
                    return Game.SingletonRepository.Get<BirthStage>(nameof(GenderSelectionBirthStage));
                case 'h':
                    Game.ShowManual();
                    break;
            }
        }
        return null;
    }
}
