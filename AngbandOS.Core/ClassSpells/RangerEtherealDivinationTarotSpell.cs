internal class RangerEtherealDivinationTarotSpell : ClassSpell
{
    private RangerEtherealDivinationTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellEtherealDivination);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 33;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 50;
}