[Serializable]
internal class MonkTheFoolTarotSpell : ClassSpell
{
    private MonkTheFoolTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTheFool);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}