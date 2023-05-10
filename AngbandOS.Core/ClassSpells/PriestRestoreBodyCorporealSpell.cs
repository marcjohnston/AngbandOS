[Serializable]
internal class PriestRestoreBodyCorporealSpell : ClassSpell
{
    private PriestRestoreBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreBody);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 120;
}