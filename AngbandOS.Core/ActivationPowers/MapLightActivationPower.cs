using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Map the local area.
    /// </summary>
    [Serializable]
    internal class MapLightActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It shines brightly...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Level.MapArea();
            saveGame.LightArea(Program.Rng.DiceRoll(2, 15), 3);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(50) + 50;

        public override int Value => 500;

        public override string Description => "light (dam 2d15) & map area every 50+d50 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}
