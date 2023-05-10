internal class PaladinDetectUnlifeDeathSpell : ClassSpell
{
    private PaladinDetectUnlifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectUnlife);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}