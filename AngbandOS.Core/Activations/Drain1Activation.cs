﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Drain up to 100 life from an opponent.  This particular drain life is unique, in that, if the power doesn't affect a monster, it doesn't need to be recharged.
    /// </summary>
    [Serializable]
    internal class Drain1Activation : DirectionalActivation
    {
        private Drain1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override string? PreActivationMessage => "It glows black...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(100) + 100;

        protected override bool Activate(int direction)
        {
            return SaveGame.DrainLife(direction, 100);
        }

        public override int Value => 500;

        public override string Description => "drain life (100) every 100+d100 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}