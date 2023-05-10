[Serializable]
internal class CultistWraithformDeathSpell : ClassSpell
{
    private CultistWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 123;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}