﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Mass carnage creatures near the player.
    /// </summary>
    [Serializable]
    internal class MassGenoActivation : Activation
    {
        private MassGenoActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "It lets out a long, shrill note...";

        public override bool Activate()
        {
            SaveGame.MassCarnage(true);
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 10000;

        public override string Description => "mass carnage every 1000 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}