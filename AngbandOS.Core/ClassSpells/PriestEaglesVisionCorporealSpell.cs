[Serializable]
internal class PriestEaglesVisionCorporealSpell : ClassSpell
{
    private PriestEaglesVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellEaglesVision);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}