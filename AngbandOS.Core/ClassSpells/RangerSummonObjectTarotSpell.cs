[Serializable]
internal class RangerSummonObjectTarotSpell : ClassSpell
{
    private RangerSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 22;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}