[Serializable]
internal class CultistAnnihilationDeathSpell : ClassSpell
{
    private CultistAnnihilationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellAnnihilation);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}