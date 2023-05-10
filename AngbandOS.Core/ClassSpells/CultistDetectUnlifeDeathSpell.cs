internal class CultistDetectUnlifeDeathSpell : ClassSpell
{
    private CultistDetectUnlifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectUnlife);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}