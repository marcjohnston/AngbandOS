//namespace AngbandOS.Core.Activations
//{
//    [Serializable]
//    internal class BreatheLightingActivation : DirectionalActivation
//    {
//        private BreatheLightingActivation(SaveGame saveGame) : base(saveGame) { }

//        protected override string? PostAimingMessage => "You breathe lightning.";

//        public override int RandomChance => throw new NotImplementedException();

//        public override int Value => throw new NotImplementedException();

//        public override string Description => throw new NotImplementedException();

//        public override Action<IItemCharacteristics> ActivateSpecialSustain => throw new NotImplementedException();

//        public override Action<IItemCharacteristics> ActivateSpecialPower => throw new NotImplementedException();

//        public override Action<IItemCharacteristics> ActivateSpecialAbility => throw new NotImplementedException();

//        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(450) + 450;

//        protected override bool Activate(int direction)
//        {
//            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), direction, 100, -2);
//            return true;
//        }
//    }
//}
