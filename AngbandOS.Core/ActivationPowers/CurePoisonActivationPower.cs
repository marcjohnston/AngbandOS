using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Remove fear and poison.
    /// </summary>
    [Serializable]
    internal class CurePoisonActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows deep blue...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.SetTimedFear(0);
            saveGame.Player.SetTimedPoison(0);
            return true;
        }

        public override int RechargeTime(Player player) => 5;

        public override int Value => 250; // TODO: This value was not present in the original source and needs to be synched once updated.

        public override string Description => "remove fear and cure poison every 5 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResChaos;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
