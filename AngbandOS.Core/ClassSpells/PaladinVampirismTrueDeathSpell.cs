[Serializable]
internal class PaladinVampirismTrueDeathSpell : ClassSpell
{
    private PaladinVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 125;
}