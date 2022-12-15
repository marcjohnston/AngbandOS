using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Banish evil creatures.
    /// </summary>
    [Serializable]
    internal class BanishEvilActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            if (saveGame.BanishEvil(100))
            {
                saveGame.MsgPrint("The power of the artifact banishes evil!");
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250 + Program.Rng.DieRoll(250);

        public override int Value => 3000;

        public override string Description => "banish evil every 250+d250 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
