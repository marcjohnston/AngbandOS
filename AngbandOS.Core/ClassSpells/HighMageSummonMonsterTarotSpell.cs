[Serializable]
internal class HighMageSummonMonsterTarotSpell : ClassSpell
{
    private HighMageSummonMonsterTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonMonster);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}