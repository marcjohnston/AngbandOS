using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a shard ball for 120 + level damage.
    /// </summary>
    [Serializable]
    internal class ShardActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

        public override string PreActivationMessage => "";  // There is no message for this artifact power.

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            SaveGame.Instance.FireBall(new ProjectShard(), direction, 120 + saveGame.Player.Level, 2);
            return true;
        }

        public override int Value => 5000;

        public override string Description => "shard ball (120+level) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResBlind;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
