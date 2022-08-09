using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
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
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (!targetEngine.TgtPt(out int ii, out int ij))
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

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}
