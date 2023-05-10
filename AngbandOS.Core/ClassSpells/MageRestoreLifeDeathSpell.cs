internal class MageRestoreLifeDeathSpell : ClassSpell
{
    private MageRestoreLifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRestoreLife);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 50;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 150;
}