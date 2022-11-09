using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Light the area.
    /// </summary>
    [Serializable]
    internal class LightActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It wells with clear light...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.LightArea(Program.Rng.DiceRoll(2, 15), 3);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(10) + 10;

        public override int Value => 150;

        public override string Description => "light area (dam 2d15) every 10+d10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
