[Serializable]
internal class CultistTeleportTarotSpell : ClassSpell
{
    private CultistTeleportTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleport);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}