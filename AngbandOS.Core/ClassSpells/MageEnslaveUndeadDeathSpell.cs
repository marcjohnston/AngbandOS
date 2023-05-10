internal class MageEnslaveUndeadDeathSpell : ClassSpell
{
    private MageEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}