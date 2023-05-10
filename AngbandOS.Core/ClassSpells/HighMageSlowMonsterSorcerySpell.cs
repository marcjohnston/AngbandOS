[Serializable]
internal class HighMageSlowMonsterSorcerySpell : ClassSpell
{
    private HighMageSlowMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSlowMonster);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 5;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 7;
}