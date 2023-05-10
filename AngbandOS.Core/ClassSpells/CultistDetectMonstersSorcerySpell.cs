internal class CultistDetectMonstersSorcerySpell : ClassSpell
{
    private CultistDetectMonstersSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectMonsters);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 4;
}