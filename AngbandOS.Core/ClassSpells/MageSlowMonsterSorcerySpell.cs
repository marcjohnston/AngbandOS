[Serializable]
internal class MageSlowMonsterSorcerySpell : ClassSpell
{
    private MageSlowMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSlowMonster);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}