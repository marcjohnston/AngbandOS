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
        SaveGame.TimedHaste.SetValue();
        SaveGame.TimedSlow.SetValue();
        SaveGame.TimedBlindness.SetValue();
        SaveGame.TimedParalysis.SetValue();
        SaveGame.TimedConfusion.SetValue();
        SaveGame.TimedFear.SetValue();
        SaveGame.TimedHallucinations.SetValue();
        SaveGame.TimedPoison.SetValue();
        SaveGame.TimedBleeding.SetValue();
        SaveGame.TimedStun.SetValue();
        SaveGame.TimedProtectionFromEvil.SetValue();
        SaveGame.TimedInvulnerability.SetValue();
        SaveGame.TimedHeroism.SetValue();
        SaveGame.TimedSuperheroism.SetValue();
        SaveGame.TimedStoneskin.SetValue();
        SaveGame.TimedBlessing.SetValue();
        SaveGame.TimedSeeInvisibility.SetValue();
        SaveGame.TimedEtherealness.SetValue();
        SaveGame.TimedInfravision.SetValue();
        SaveGame.TimedAcidResistance.SetValue();
        SaveGame.TimedLightningResistance.SetValue();
        SaveGame.TimedFireResistance.SetValue();
        SaveGame.TimedColdResistance.SetValue();
        SaveGame.TimedPoisonResistance.SetValue();
        SaveGame.Health.Value = SaveGame.MaxHealth;
        SaveGame.Mana.Value = SaveGame.MaxMana.Value;
        SaveGame.TimedBlindness.SetValue();
        SaveGame.TimedConfusion.SetValue();
        SaveGame.TimedStun.SetValue();
        SaveGame.NewLevelFlag = true;
        SaveGame.CameFrom = LevelStart.StartWalk;
    }
}
