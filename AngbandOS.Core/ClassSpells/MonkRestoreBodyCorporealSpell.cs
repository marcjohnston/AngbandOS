internal class MonkRestoreBodyCorporealSpell : ClassSpell
{
    private MonkRestoreBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreBody);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 120;
}