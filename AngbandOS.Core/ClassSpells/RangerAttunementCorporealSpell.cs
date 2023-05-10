[Serializable]
internal class RangerAttunementCorporealSpell : ClassSpell
{
    private RangerAttunementCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellAttunement);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 60;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 120;
}