using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Summon animals.
    /// </summary>
    [Serializable]
    internal class SummonAnimalActivationPower : ActivationPower
    {
        public override int RandomChance => 40;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level)
        {
            level.Monsters.SummonSpecificFriendly(player.MapY, player.MapX, player.Level, Constants.SummonAnimalRanger, true);
            return true;
        }

        public override int RechargeTime(Player player) => 200 + Program.Rng.DieRoll(300);

        public override int Value => 10000;

        public override string Description => "summon animal every 200+d300 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
