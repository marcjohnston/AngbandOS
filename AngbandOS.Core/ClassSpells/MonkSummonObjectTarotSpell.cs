[Serializable]
internal class MonkSummonObjectTarotSpell : ClassSpell
{
    private MonkSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}