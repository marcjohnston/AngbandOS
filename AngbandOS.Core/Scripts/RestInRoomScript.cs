﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInRoomScript : Script, IScript
{
    private RestInRoomScript(Game game) : base(game) { }

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
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
        Game.SetFood(Constants.PyFoodMax - 1);
        foreach (Town town in Game.SingletonRepository.Towns)
        {
            foreach (Store store in town.Stores)
            {
                if (store.StoreFactory.PerformsMaintenanceWhenResting)
                {
                    store.StoreMaint();
                }
            }
        }
        Game.HasteTimer.SetValue();
        Game.SlowTimer.SetValue();
        Game.BlindnessTimer.SetValue();
        Game.ParalysisTimer.SetValue();
        Game.ConfusedTimer.SetValue();
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
        Game.BlessingTimer.SetValue();
        Game.SeeInvisibilityTimer.SetValue();
        Game.EtherealnessTimer.SetValue();
        Game.InfravisionTimer.SetValue();
        Game.AcidResistanceTimer.SetValue();
        Game.LightningResistanceTimer.SetValue();
        Game.FireResistanceTimer.SetValue();
        Game.ColdResistanceTimer.SetValue();
        Game.PoisonResistanceTimer.SetValue();
        Game.Health.Value = Game.MaxHealth.Value;
        Game.Mana.Value = Game.MaxMana.Value;
        Game.BlindnessTimer.SetValue();
        Game.ConfusedTimer.SetValue();
        Game.StunTimer.SetValue();
        Game.NewLevelFlag = true;
        Game.CameFrom = LevelStart.StartWalk;
    }
}