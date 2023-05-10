[Serializable]
internal class PriestHasteCorporealSpell : ClassSpell
{
    private PriestHasteCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHaste);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 17;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 10;
}