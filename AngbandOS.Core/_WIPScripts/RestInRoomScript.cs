// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInRoomScript : Script, IScript, ICastSpellScript
{
    private RestInRoomScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the rest in a room script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool toDusk = Game.Race.RestsTillDuskInsteadOfDawn;
        if (toDusk)
        {
            Game.ToNextDusk();
            Game.MsgPrint("You awake, ready for the night.");
            Game.MsgPrint("You eat a tasty supper.");
        }
        else
        {
            Game.ToNextDawn();
            Game.MsgPrint("You awake refreshed for the new day.");
            Game.MsgPrint("You eat a hearty breakfast.");
        }
        Game.DecayFavour();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        Game.SetFood(Constants.PyFoodMax - 1);
        foreach (Town town in Game.SingletonRepository.Get<Town>())
        {
            foreach (Store store in town.Stores)
            {
                if (store.StoreFactory.PerformsMaintenanceWhenResting)
                {
                    store.StoreMaint();
                }
            }
        }
        // TODO: This is missing telepathy
        Game.HasteTimer.SetValue();
        Game.SlowTimer.SetValue();
        Game.BlindnessTimer.SetValue();
        Game.ParalysisTimer.SetValue();
        Game.ConfusionTimer.SetValue();
        Game.FearTimer.SetValue();
        Game.HallucinationsTimer.SetValue();
        Game.PoisonTimer.SetValue();
        Game.BleedingTimer.SetValue();
        Game.StunTimer.SetValue();
        Game.ProtectionFromEvilTimer.SetValue();
        Game.InvulnerabilityTimer.SetValue();
        Game.HeroismTimer.SetValue();
        Game.SuperheroismTimer.SetValue();
        Game.StoneskinTimer.SetValue();
        Game.RunScript(nameof(BlessingQuietResetTimerScript));
        Game.SeeInvisibilityTimer.SetValue();
        Game.EtherealnessTimer.SetValue();
        Game.InfravisionTimer.SetValue();
        Game.RunScript(nameof(AcidResistanceQuietResetTimerScript));
        Game.LightningResistanceTimer.SetValue();
        Game.RunScript(nameof(FireResistanceQuietResetTimerScript));
        Game.ColdResistanceTimer.SetValue();
        Game.PoisonResistanceTimer.SetValue();
        Game.Health.IntValue = Game.MaxHealth.IntValue;
        Game.Mana.IntValue = Game.MaxMana.IntValue;
        Game.BlindnessTimer.SetValue();
        Game.ConfusionTimer.SetValue();
        Game.StunTimer.SetValue();
        Game.NewLevelFlag = true;
        Game.CameFrom = LevelStartEnum.StartWalk;
    }
}
