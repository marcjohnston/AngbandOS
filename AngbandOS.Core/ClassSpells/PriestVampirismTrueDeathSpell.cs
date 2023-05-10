[Serializable]
internal class PriestVampirismTrueDeathSpell : ClassSpell
{
    private PriestVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 125;
}