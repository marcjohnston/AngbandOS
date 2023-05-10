[Serializable]
internal class WarriorMageSlowMonsterSorcerySpell : ClassSpell
{
    private WarriorMageSlowMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSlowMonster);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}