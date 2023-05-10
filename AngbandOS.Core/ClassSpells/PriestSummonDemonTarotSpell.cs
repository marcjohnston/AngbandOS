[Serializable]
internal class PriestSummonDemonTarotSpell : ClassSpell
{
    private PriestSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 115;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}