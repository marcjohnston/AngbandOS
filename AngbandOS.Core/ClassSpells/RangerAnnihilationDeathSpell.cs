[Serializable]
internal class RangerAnnihilationDeathSpell : ClassSpell
{
    private RangerAnnihilationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellAnnihilation);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 99;
    public override int ManaCost => 0;
    public override int BaseFailure => 0;
    public override int FirstCastExperience => 0;
}