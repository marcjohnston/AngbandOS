internal class CultistTeleportSelfChaosSpell : ClassSpell
{
    private CultistTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 7;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 5;
}