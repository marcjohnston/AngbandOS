using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a 'magic missile' cone that does 300 damage.
    /// </summary>
    [Serializable]
    internal class BaMiss3ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => ""; // No message is displayed to the player.

        protected override string PostAimingMessage => "You breathe the elements.";

        public override int RechargeTime(Player player) => 500;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            SaveGame.Instance.FireBall(new ProjectMissile(), direction, 300, -4);
            return true;
        }

        public override int Value => 5000;

        public override string Description => "elemental breath (300) every 500 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}
