﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Give us temporary etherealness.
    /// </summary>
    [Serializable]
    internal class WraithActivation : Activation
    {
        private WraithActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 5;

        public override string? PreActivationMessage => "";

        public override bool Activate()
        {
            SaveGame.Player.TimedEtherealness.AddTimer(Program.Rng.DieRoll(SaveGame.Player.Level / 2) + (SaveGame.Player.Level / 2));
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 25000;

        public override string Description => "wraith form (level/2 + d(level/2)) every 1000 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}