using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Bless us and make us a superhero.
    /// </summary>
    [Serializable]
    internal class BerserkActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level)
        {
            player.SetTimedSuperheroism(player.TimedSuperheroism + Program.Rng.DieRoll(50) + 50);
            player.SetTimedBlessing(player.TimedBlessing + Program.Rng.DieRoll(50) + 50);
            return true;
        }

        public override int RechargeTime(Player player) => 100 + Program.Rng.DieRoll(100);

        public override int Value => 800;

        public override string Description => "heroism and berserk (dur 50+d50) every 100+d100 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}
