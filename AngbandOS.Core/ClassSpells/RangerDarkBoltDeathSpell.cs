[Serializable]
internal class RangerDarkBoltDeathSpell : ClassSpell
{
    private RangerDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 40;
}