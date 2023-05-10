internal class PriestEtherealDivinationTarotSpell : ClassSpell
{
    private PriestEtherealDivinationTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellEtherealDivination);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 50;
}