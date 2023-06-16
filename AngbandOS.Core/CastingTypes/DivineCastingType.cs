namespace AngbandOS.Core.CastingTypes;

[Serializable]
internal class DivineCastingType : CastingType
{
    private DivineCastingType(SaveGame saveGame) : base(saveGame) { }
    public override int Levels => SaveGame.Player.Level - SaveGame.SpellFirst + 1;

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

    public override string GetBookTitle(BookItem bookItem)
    {
        return $"{Pluralize("Book", bookItem.Count)} of {bookItem.DivineTitle}";
    }
}