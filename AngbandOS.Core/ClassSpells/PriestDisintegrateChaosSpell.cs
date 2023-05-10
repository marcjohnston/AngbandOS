internal class PriestDisintegrateChaosSpell : ClassSpell
{
    private PriestDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}