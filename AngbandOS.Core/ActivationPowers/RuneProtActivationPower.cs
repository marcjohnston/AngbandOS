using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Place an ElderSign.
    /// </summary>
    [Serializable]
    internal class RuneProtActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows light blue...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.ElderSign();
            return true;
        }

        public override int RechargeTime(Player player) => 400;

        public override int Value => 10000;

        public override string Description => "rune of protection every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
