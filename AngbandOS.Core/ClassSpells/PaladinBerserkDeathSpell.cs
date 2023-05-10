[Serializable]
internal class PaladinBerserkDeathSpell : ClassSpell
{
    private PaladinBerserkDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBerserk);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 180;
}