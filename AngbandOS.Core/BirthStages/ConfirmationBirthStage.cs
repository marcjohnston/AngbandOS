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
    private ConfirmationBirthStage(Game game) : base(game) { }

    public override BirthStage? Render()
    {
        Game.GetStats();
        Game.GetExtra();
        Game.GetAhw();
        Game.GetHistory();
        Game.GetMoney();
        Game.RefreshGods();

        Game.Talents = new List<Talent>();
        foreach (Talent talent in Game.SingletonRepository.Get<Talent>())
        {
            Game.Talents.Add(talent);
        }
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
            RenderCharacterScript showCharacterSheet = (RenderCharacterScript)Game.SingletonRepository.Get<Script>(nameof(RenderCharacterScript));
            showCharacterSheet.ExecuteScript();
            char c = Game.Inkey();
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
