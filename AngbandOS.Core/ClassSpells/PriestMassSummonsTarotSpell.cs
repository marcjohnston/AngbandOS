[Serializable]
internal class PriestMassSummonsTarotSpell : ClassSpell
{
    private PriestMassSummonsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMassSummons);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 110;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}