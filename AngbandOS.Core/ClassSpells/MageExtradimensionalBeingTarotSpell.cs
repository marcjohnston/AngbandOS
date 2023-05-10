[Serializable]
internal class MageExtradimensionalBeingTarotSpell : ClassSpell
{
    private MageExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}