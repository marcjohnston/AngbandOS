[Serializable]
internal class CultistSummonObjectTarotSpell : ClassSpell
{
    private CultistSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 23;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}