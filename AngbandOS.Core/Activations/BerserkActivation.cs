﻿namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Bless us and make us a superhero.
    /// </summary>
    [Serializable]
    internal class BerserkActivation : Activation
    {
        private BerserkActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "";

        public override bool Activate()
        {
            SaveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(50) + 50);
            SaveGame.Player.TimedBlessing.AddTimer(Program.Rng.DieRoll(50) + 50);
            return true;
        }

        public override int RechargeTime(Player player) => 100 + Program.Rng.DieRoll(100);

        public override int Value => 800;

        public override string Description => "heroism and berserk (dur 50+d50) every 100+d100 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}