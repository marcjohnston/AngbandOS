﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Place an ElderSign.
    /// </summary>
    [Serializable]
    internal class RuneProtActivation : Activation
    {
        private RuneProtActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 25;

        public override string? PreActivationMessage => "It glows light blue...";

        public override bool Activate()
        {
            SaveGame.ElderSign();
            return true;
        }

        public override int RechargeTime(Player player) => 400;

        public override int Value => 10000;

        public override string Description => "rune of protection every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}