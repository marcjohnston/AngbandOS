[Serializable]
internal class PriestBerserkDeathSpell : ClassSpell
{
    private PriestBerserkDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBerserk);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 180;
}