[Serializable]
internal class CultistFrostBoltNatureSpell : ClassSpell
{
    private CultistFrostBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFrostBolt);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 13;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}