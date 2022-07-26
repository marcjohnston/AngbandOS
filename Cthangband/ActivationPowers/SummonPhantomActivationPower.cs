using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Summon phantom warriors or beasts.
    /// </summary>
    [Serializable]
    internal class SummonPhantomActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "You summon a phantasmal servant.";

        public override bool Activate(Player player, Level level)
        {
            level.Monsters.SummonSpecificFriendly(player.MapY, player.MapX, SaveGame.Instance.Difficulty, Constants.SummonPhantom, true);
            return true;
        }

        public override int RechargeTime(Player player) => 200 + Program.Rng.DieRoll(200);

        public override int Value => 12000;

        public override string Description => "summon phantasmal servant every 200+d200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResNexus;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}
