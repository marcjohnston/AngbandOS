internal class PaladinNetherBoltDeathSpell : ClassSpell
{
    private PaladinNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}