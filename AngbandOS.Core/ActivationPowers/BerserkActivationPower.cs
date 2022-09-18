using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Bless us and make us a superhero.
    /// </summary>
    [Serializable]
    internal class BerserkActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + Program.Rng.DieRoll(50) + 50);
            saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(50) + 50);
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
