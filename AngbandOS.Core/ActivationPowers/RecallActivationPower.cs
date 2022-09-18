using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Word of Recall.
    /// </summary>
    [Serializable]
    internal class RecallActivationPower : ActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows soft white...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.ToggleRecall();
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 7500;

        public override string Description => "word of recall every 200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
