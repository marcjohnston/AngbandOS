﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Word of Recall.
    /// </summary>
    [Serializable]
    internal class RecallActivation : Activation
    {
        private RecallActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override string? PreActivationMessage => "It glows soft white...";

        public override bool Activate()
        {
            SaveGame.Player.ToggleRecall();
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 7500;

        public override string Description => "word of recall every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}