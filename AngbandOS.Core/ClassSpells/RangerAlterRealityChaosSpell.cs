internal class RangerAlterRealityChaosSpell : ClassSpell
{
    private RangerAlterRealityChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellAlterReality);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 35;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 150;
}