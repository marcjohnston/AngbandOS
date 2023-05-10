[Serializable]
internal class HighMageStasisSorcerySpell : ClassSpell
{
    private HighMageStasisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellStasis);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 20;
}