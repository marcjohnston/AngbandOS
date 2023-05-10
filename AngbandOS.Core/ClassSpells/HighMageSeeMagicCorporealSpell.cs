[Serializable]
internal class HighMageSeeMagicCorporealSpell : ClassSpell
{
    private HighMageSeeMagicCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeMagic);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 40;
}