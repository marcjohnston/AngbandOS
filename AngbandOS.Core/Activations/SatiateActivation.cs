﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Fill us up.
    /// </summary>
    [Serializable]
    internal class SatiateActivation : Activation
    {
        private SatiateActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override bool Activate()
        {
            SaveGame.Player.SetFood(Constants.PyFoodMax - 1);
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 2000;

        public override string Description => "satisfy hunger every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}