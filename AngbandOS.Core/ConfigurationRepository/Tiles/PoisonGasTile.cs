// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PoisonGasTile : Tile
{
    private PoisonGasTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override string SymbolName => nameof(CaretSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    protected override string? AlterActionName => nameof(DisarmAlterAction);
    public override string Description => "gas trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
    public override void StepOn(GridTile tile)
    {
        // Poison the player
        SaveGame.MsgPrint("A pungent green gas surrounds you!");
        if (!SaveGame.HasPoisonResistance && SaveGame.TimedPoisonResistance.TurnsRemaining == 0)
        {
            // Hagarg Ryonis may save you from the poison
            if (SaveGame.DieRoll(10) <= SaveGame.Religion.GetNamedDeity(GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                SaveGame.TimedPoison.AddTimer(SaveGame.RandomLessThan(20) + 10);
            }
        }
    }
}
