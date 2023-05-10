[Serializable]
internal class MageCarnageDeathSpell : ClassSpell
{
    private MageCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellCarnage);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 25;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 25;
}