[Serializable]
internal class PaladinCarnageDeathSpell : ClassSpell
{
    private PaladinCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellCarnage);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 35;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 100;
}