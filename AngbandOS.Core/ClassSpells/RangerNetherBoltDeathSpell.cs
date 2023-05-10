[Serializable]
internal class RangerNetherBoltDeathSpell : ClassSpell
{
    private RangerNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 26;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}