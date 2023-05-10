[Serializable]
internal class PaladinMaledictionDeathSpell : ClassSpell
{
    private PaladinMaledictionDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMalediction);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}