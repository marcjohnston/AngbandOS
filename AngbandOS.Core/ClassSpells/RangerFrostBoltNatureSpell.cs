internal class RangerFrostBoltNatureSpell : ClassSpell
{
    private RangerFrostBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFrostBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 9;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 4;
}