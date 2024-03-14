// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CastingTypes;

[Serializable]
internal class DivineCastingType : CastingType
{
    private DivineCastingType(SaveGame saveGame) : base(saveGame) { }

    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;

    /// <summary>
    /// Returns "recite" because the divine casting type recites prayers; as opposed to casting spells.
    /// </summary>
    public override string CastVerb => "recite";

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers for magic.
    /// </summary>
    public override string SpellNoun => "prayer";

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers.
    /// </summary>
    public override string MagicType => "prayer";

    /// <summary>
    /// Returns false, because the diving casting type does not allow the player to choose which prayer to learn.
    /// </summary>
    public override bool CanChooseSpellToStudy => false;

    public override string GetBookTitle(Item bookItem)
    {
        BookItemFactory bookItemFactory = (BookItemFactory)bookItem.Factory;
        return $"{SaveGame.CountPluralize("Book", bookItem.Count)} of {bookItemFactory.DivineTitle}";
    }
}