﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Recharge an item.
    /// </summary>
    [Serializable]
    internal class RechargeActivation : Activation
    {
        private RechargeActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override string? PreActivationMessage => "";

        public override bool Activate()
        {
            SaveGame.Recharge(60);
            return true;
        }

        public override int RechargeTime(Player player) => 70;

        public override int Value => 1000;

        public override string Description => "recharging every 70 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}