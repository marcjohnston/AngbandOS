[Serializable]
internal class CultistSlowMonsterSorcerySpell : ClassSpell
{
    private CultistSlowMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSlowMonster);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}