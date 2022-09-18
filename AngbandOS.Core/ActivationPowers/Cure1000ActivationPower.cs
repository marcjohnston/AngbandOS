using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Heal 1000 health and remove all bleeding.
    /// </summary>
    [Serializable]
    internal class Cure1000ActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "It glows a bright white...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.MsgPrint("You feel much better...");
            saveGame.Player.RestoreHealth(1000);
            saveGame.Player.SetTimedBleeding(0);
            return true;
        }

        public override int RechargeTime(Player player) => 888;

        public override int Value => 15000;

        public override string Description => "heal 1000 hit points every 888 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}