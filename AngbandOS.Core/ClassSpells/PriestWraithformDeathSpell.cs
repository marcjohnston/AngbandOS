[Serializable]
internal class PriestWraithformDeathSpell : ClassSpell
{
    private PriestWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 111;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}