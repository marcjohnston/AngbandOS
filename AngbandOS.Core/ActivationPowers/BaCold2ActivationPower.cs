using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a frost ball that does 100 damage.
    /// </summary>
    [Serializable]
    internal class BaCold2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

        public override string PreActivationMessage => "It glows an intense blue...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 300;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectCold(), direction, 100, 2);
            return true;
        }

        public override int Value => 1250;

        public override string Description => "ball of cold (100) every 300 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResBlind;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
