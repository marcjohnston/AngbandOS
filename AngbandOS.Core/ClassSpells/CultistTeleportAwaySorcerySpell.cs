internal class CultistTeleportAwaySorcerySpell : ClassSpell
{
    private CultistTeleportAwaySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportAway);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}