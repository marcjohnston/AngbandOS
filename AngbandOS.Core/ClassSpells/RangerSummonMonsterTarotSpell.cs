[Serializable]
internal class RangerSummonMonsterTarotSpell : ClassSpell
{
    private RangerSummonMonsterTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonMonster);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 32;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 9;
}