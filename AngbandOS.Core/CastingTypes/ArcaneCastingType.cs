// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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