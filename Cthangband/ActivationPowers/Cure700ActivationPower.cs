using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Heal 700 health and remove all bleeding.
    /// </summary>
    [Serializable]
    internal class Cure700ActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows deep blue...";

        public override bool Activate(Player player, Level level)
        {
            Profile.Instance.MsgPrint("You feel a warm tingling inside...");
            player.RestoreHealth(700);
            player.SetTimedBleeding(0);
            return true;
        }

        public override int RechargeTime(Player player) => 250;

        public override int Value => 10000;

        public override string Description => "heal 700 hit points every 250 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
