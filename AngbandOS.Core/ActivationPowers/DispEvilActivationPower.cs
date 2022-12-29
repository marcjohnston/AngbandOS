namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Dispel evil with a strength of x5.
    /// </summary>
    [Serializable]
    internal class DispEvilActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It floods the area with goodness...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(300) + 300;

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.DispelEvil(saveGame.Player.Level * 5);
            return true;
        }

        public override int Value => 4000;

        public override string Description => "dispel evil (level*5) every 300+d300 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
