[Serializable]
internal class PaladinVampiricDrainDeathSpell : ClassSpell
{
    private PaladinVampiricDrainDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricDrain);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 16;
}