[Serializable]
internal class RangerArcaneBindingChaosSpell : ClassSpell
{
    private RangerArcaneBindingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellArcaneBinding);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 25;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 45;
}