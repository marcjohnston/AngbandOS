// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInRoomScript : Script, IScript
{
    private RestInRoomScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the rest in a room script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool toDusk = SaveGame.Race.RestsTillDuskInsteadOfDawn;
        if (toDusk)
        {
            SaveGame.GameTime.ToNextDusk();
            SaveGame.MsgPrint("You awake, ready for the night.");
            SaveGame.MsgPrint("You eat a tasty supper.");
        }
        else
        {
            SaveGame.GameTime.ToNextDawn();
            SaveGame.MsgPrint("You awake refreshed for the new day.");
            SaveGame.MsgPrint("You eat a hearty breakfast.");
        }
        SaveGame.DecayFavour();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
        SaveGame.SetFood(Constants.PyFoodMax - 1);
        foreach (Town town in SaveGame.SingletonRepository.Towns)
        {
            foreach (Store store in town.Stores)
            {
                if (store.StoreFactory.PerformsMaintenanceWhenResting)
                {
                    store.StoreMaint();
                }
            }
        }
        SaveGame.HasteTimer.SetValue();
        SaveGame.SlowTimer.SetValue();
        SaveGame.BlindnessTimer.SetValue();
        SaveGame.ParalysisTimer.SetValue();
        SaveGame.ConfusedTimer.SetValue();
        SaveGame.FearTimer.SetValue();
        SaveGame.HallucinationsTimer.SetValue();
        SaveGame.PoisonTimer.SetValue();
        SaveGame.BleedingTimer.SetValue();
        SaveGame.StunTimer.SetValue();
        SaveGame.ProtectionFromEvilTimer.SetValue();
        SaveGame.InvulnerabilityTimer.SetValue();
        SaveGame.HeroismTimer.SetValue();
        SaveGame.SuperheroismTimer.SetValue();
        SaveGame.StoneskinTimer.SetValue();
        SaveGame.BlessingTimer.SetValue();
        SaveGame.SeeInvisibilityTimer.SetValue();
        SaveGame.EtherealnessTimer.SetValue();
        SaveGame.InfravisionTimer.SetValue();
        SaveGame.AcidResistanceTimer.SetValue();
        SaveGame.LightningResistanceTimer.SetValue();
        SaveGame.FireResistanceTimer.SetValue();
        SaveGame.ColdResistanceTimer.SetValue();
        SaveGame.PoisonResistanceTimer.SetValue();
        SaveGame.Health.Value = SaveGame.MaxHealth;
        SaveGame.Mana.Value = SaveGame.MaxMana.Value;
        SaveGame.BlindnessTimer.SetValue();
        SaveGame.ConfusedTimer.SetValue();
        SaveGame.StunTimer.SetValue();
        SaveGame.NewLevelFlag = true;
        SaveGame.CameFrom = LevelStart.StartWalk;
    }
}
