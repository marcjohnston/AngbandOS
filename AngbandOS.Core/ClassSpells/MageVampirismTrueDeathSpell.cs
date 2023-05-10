[Serializable]
internal class MageVampirismTrueDeathSpell : ClassSpell
{
    private MageVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 125;
}