[Serializable]
internal class PaladinMassCarnageDeathSpell : ClassSpell
{
    private PaladinMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}