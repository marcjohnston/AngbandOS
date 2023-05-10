[Serializable]
internal class PriestNetherBoltDeathSpell : ClassSpell
{
    private PriestNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}