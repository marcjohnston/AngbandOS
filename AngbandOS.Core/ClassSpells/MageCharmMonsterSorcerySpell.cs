[Serializable]
internal class MageCharmMonsterSorcerySpell : ClassSpell
{
    private MageCharmMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellCharmMonster);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}