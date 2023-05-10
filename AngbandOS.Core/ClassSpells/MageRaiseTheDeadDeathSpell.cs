[Serializable]
internal class MageRaiseTheDeadDeathSpell : ClassSpell
{
    private MageRaiseTheDeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRaiseTheDead);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}