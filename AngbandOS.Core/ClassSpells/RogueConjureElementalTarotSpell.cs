[Serializable]
internal class RogueConjureElementalTarotSpell : ClassSpell
{
    private RogueConjureElementalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellConjureElemental);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 12;
}