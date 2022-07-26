using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us temporary invulnerabliity.
    /// </summary>
    [Serializable]
    internal class InvulnActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level, Item item)
        {
            player.SetTimedInvulnerability(player.TimedInvulnerability + Program.Rng.DieRoll(8) + 8);
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 25000;

        public override string Description => "invulnerability (dur 8+d8) every 1000 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}
