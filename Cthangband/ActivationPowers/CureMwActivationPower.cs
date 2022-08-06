using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Heal 4d8 health and reduce bleeding.
    /// </summary>
    [Serializable]
    internal class CureMwActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It radiates deep purple...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
            saveGame.Player.SetTimedBleeding((saveGame.Player.TimedBleeding / 2) - 50);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(3) + 3;

        public override int Value => 750;

        public override string Description => "heal 4d8 & wounds every 3+d3 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResNexus;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}
