[Serializable]
internal class RangerRestoreBodyCorporealSpell : ClassSpell
{
    private RangerRestoreBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreBody);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 120;
}