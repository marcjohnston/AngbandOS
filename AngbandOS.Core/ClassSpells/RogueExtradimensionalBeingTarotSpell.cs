[Serializable]
internal class RogueExtradimensionalBeingTarotSpell : ClassSpell
{
    private RogueExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 150;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}