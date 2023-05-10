[Serializable]
internal class PaladinRestoreLifeDeathSpell : ClassSpell
{
    private PaladinRestoreLifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRestoreLife);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 52;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 150;
}