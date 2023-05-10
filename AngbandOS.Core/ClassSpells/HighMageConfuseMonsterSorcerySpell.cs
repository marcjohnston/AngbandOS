[Serializable]
internal class HighMageConfuseMonsterSorcerySpell : ClassSpell
{
    private HighMageConfuseMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellConfuseMonster);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 1;
}