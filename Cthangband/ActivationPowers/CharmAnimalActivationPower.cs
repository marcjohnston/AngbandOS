using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Charm an animal.
    /// </summary>
    [Serializable]
    internal class CharmAnimalActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 50;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 300;

        protected override bool Activate(Player player, Level level, Item item, int direction)
        {
            SaveGame.Instance.SpellEffects.CharmAnimal(direction, player.Level);
            return true;
        }

        public override int Value => 7500;

        public override string Description => "charm animal every 300 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}
