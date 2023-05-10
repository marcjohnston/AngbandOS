[Serializable]
internal class RangerVampiricDrainDeathSpell : ClassSpell
{
    private RangerVampiricDrainDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricDrain);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 5;
}