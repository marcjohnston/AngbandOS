using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Banish evil creatures.
    /// </summary>
    [Serializable]
    internal class BanishEvilActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            if (saveGame.BanishEvil(100))
            {
                saveGame.MsgPrint("The power of the artifact banishes evil!");
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250 + Program.Rng.DieRoll(250);

        public override int Value => 3000;

        public override string Description => "banish evil every 250+d250 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResConf;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}
