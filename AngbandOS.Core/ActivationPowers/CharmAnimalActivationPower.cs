using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
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

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.CharmAnimal(direction, saveGame.Player.Level);
            return true;
        }

        public override int Value => 7500;

        public override string Description => "charm animal every 300 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
