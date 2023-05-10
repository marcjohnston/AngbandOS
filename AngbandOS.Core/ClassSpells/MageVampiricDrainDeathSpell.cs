[Serializable]
internal class MageVampiricDrainDeathSpell : ClassSpell
{
    private MageVampiricDrainDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricDrain);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 20;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 16;
}