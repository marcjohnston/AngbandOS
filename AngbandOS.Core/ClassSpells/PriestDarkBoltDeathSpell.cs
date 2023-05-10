[Serializable]
internal class PriestDarkBoltDeathSpell : ClassSpell
{
    private PriestDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 15;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 15;
}