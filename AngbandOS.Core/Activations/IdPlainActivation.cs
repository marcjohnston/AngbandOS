﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Identify an item.
    /// </summary>
    [Serializable]
    internal class IdPlainActivation : Activation
    {
        private IdPlainActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 75;

        public override string? PreActivationMessage => "";

        public override bool Activate()
        {
            return SaveGame.IdentifyItem();
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 1250;

        public override string Description => "identify spell every 10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}