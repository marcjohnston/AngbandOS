internal class MageConfuseMonsterSorcerySpell : ClassSpell
{
    private MageConfuseMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellConfuseMonster);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}