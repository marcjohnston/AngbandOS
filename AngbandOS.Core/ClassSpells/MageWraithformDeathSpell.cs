[Serializable]
internal class MageWraithformDeathSpell : ClassSpell
{
    private MageWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}