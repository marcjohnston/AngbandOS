namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Short range teleport to a specific destination.
    /// </summary>
    [Serializable]
    internal class DimDoorActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "You open a dimensional gate. Choose a destination.";

        public override bool Activate(SaveGame saveGame)
        {
            if (!saveGame.TgtPt(out int ii, out int ij))
            {
                return false;
            }
            saveGame.Player.Energy -= 60 - saveGame.Player.Level;
            if (!saveGame.Level.GridPassableNoCreature(ij, ii) ||
                saveGame.Level.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
                saveGame.Level.Distance(ij, ii, saveGame.Player.MapY, saveGame.Player.MapX) > saveGame.Player.Level + 2 ||
                Program.Rng.RandomLessThan(saveGame.Player.Level * saveGame.Player.Level / 2) == 0)
            {
                saveGame.MsgPrint("You fail to exit the astral plane correctly!");
                saveGame.Player.Energy -= 100;
                saveGame.TeleportPlayer(10);
            }
            else
            {
                saveGame.TeleportPlayerTo(ij, ii);
            }
            return true;
        }

        public override int RechargeTime(Player player) => 100;

        public override int Value => 10000;

        public override string Description => "dimension door every 100 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
