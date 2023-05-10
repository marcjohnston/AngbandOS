internal class WarriorMageCharmMonsterSorcerySpell : ClassSpell
{
    private WarriorMageCharmMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellCharmMonster);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 10;
}