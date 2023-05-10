internal class PaladinDarkBoltDeathSpell : ClassSpell
{
    private PaladinDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 20;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 15;
}