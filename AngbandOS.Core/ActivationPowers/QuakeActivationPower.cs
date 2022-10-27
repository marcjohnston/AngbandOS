using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Cause an earthquake around the player.
    /// </summary>
    [Serializable]
    internal class QuakeActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override int RechargeTime(Player player) => 50;

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 10);
            return true;
        }

        public override int Value => 600;

        public override string Description => "earthquake (rad 10) every 50 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}
