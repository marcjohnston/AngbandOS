namespace AngbandOS.Core.CastingTypes;

[Serializable]
internal class ArcaneCastingType : CastingType
{
    private ArcaneCastingType(SaveGame saveGame) : base(saveGame) { }

    public override int Levels => SaveGame.Player.Level - SaveGame.SpellFirst + 1;

    /// <summary>
    /// Returns true, because arcane spell casting requires the players hands to be uncovered or be of free-action, dexterity or typespecificvalue == 0.
    /// </summary>
    public override bool CoveredHandsRestrictCasting => true;

    /// <summary>
    /// Returns true, because arcane spell casting movement can be encumbered by the spell weight of the players armour.
    /// </summary>
    public override bool WeightEncumbersMovement => true;
}