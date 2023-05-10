[Serializable]
internal class CultistBerserkDeathSpell : ClassSpell
{
    private CultistBerserkDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBerserk);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 22;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 120;
}