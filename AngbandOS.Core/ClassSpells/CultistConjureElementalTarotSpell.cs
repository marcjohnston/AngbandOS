[Serializable]
internal class CultistConjureElementalTarotSpell : ClassSpell
{
    private CultistConjureElementalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellConjureElemental);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 32;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 12;
}