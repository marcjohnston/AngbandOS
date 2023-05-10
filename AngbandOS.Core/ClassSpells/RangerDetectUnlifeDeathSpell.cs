internal class RangerDetectUnlifeDeathSpell : ClassSpell
{
    private RangerDetectUnlifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectUnlife);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 2;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}