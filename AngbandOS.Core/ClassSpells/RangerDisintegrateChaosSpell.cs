internal class RangerDisintegrateChaosSpell : ClassSpell
{
    private RangerDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 32;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}