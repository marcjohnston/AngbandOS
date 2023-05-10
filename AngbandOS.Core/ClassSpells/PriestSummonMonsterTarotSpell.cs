internal class PriestSummonMonsterTarotSpell : ClassSpell
{
    private PriestSummonMonsterTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonMonster);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 9;
}