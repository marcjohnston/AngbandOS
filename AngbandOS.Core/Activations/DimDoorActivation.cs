// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
        SaveGame.Energy -= 60 - SaveGame.ExperienceLevel;
        if (!SaveGame.GridPassableNoCreature(ij, ii) ||
            SaveGame.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
            SaveGame.Distance(ij, ii, SaveGame.MapY, SaveGame.MapX) > SaveGame.ExperienceLevel + 2 ||
            SaveGame.Rng.RandomLessThan(SaveGame.ExperienceLevel * SaveGame.ExperienceLevel / 2) == 0)
        {
            SaveGame.MsgPrint("You fail to exit the astral plane correctly!");
            SaveGame.Energy -= 100;
            SaveGame.TeleportPlayer(10);
        }
        else
        {
            SaveGame.TeleportPlayerTo(ij, ii);
        }
        return true;
    }

    public override int RechargeTime() => 100;

    public override int Value => 10000;

    public override string Description => "dimension door every 100 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
}
