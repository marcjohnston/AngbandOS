[Serializable]
internal class MageFrostBoltNatureSpell : ClassSpell
{
    private MageFrostBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFrostBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}