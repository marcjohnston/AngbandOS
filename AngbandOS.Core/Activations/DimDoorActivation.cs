namespace AngbandOS.Core.Activations;

/// <summary>
/// Short range teleport to a specific destination.
/// </summary>
[Serializable]
internal class DimDoorActivation : Activation
{
    private DimDoorActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 10;

    public override string? PreActivationMessage => "You open a dimensional gate. Choose a destination.";

    public override bool Activate()
    {
        if (!SaveGame.TgtPt(out int ii, out int ij))
        {
            return false;
        }
        SaveGame.Player.Energy -= 60 - SaveGame.Player.Level;
        if (!SaveGame.Level.GridPassableNoCreature(ij, ii) ||
            SaveGame.Level.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
            SaveGame.Level.Distance(ij, ii, SaveGame.Player.MapY, SaveGame.Player.MapX) > SaveGame.Player.Level + 2 ||
            Program.Rng.RandomLessThan(SaveGame.Player.Level * SaveGame.Player.Level / 2) == 0)
        {
            SaveGame.MsgPrint("You fail to exit the astral plane correctly!");
            SaveGame.Player.Energy -= 100;
            SaveGame.TeleportPlayer(10);
        }
        else
        {
            SaveGame.TeleportPlayerTo(ij, ii);
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
