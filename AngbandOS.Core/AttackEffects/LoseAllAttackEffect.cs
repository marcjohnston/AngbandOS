// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class LoseAllAttackEffect : AttackEffect
{
    private LoseAllAttackEffect(Game game) : base(game) { }
    public override int Power => 2;
    public override string Description => "reduce all stats";
    public override void ApplyToPlayer(Monster monster, ref bool identified, ref int damage, ref bool blinked) // TODO: Convert to function -- the OUT REF identified, damage and blinked parameters
    {
        // Try to decrease all six ability scores
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        IdentifiedResultEnum identifiedResult = Game.TryDecreasingAbilityScore(Game.StrengthAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
        identifiedResult = Game.TryDecreasingAbilityScore(Game.DexterityAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
        identifiedResult = Game.TryDecreasingAbilityScore(Game.ConstitutionAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
        identifiedResult = Game.TryDecreasingAbilityScore(Game.IntelligenceAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
        identifiedResult = Game.TryDecreasingAbilityScore(Game.WisdomAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
        identifiedResult = Game.TryDecreasingAbilityScore(Game.CharismaAbility);
        if (identifiedResult == IdentifiedResultEnum.True)
        {
            identified = true;
        }
    }
}