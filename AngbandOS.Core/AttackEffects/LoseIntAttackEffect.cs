// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class LoseIntAttackEffect : AttackEffect
{
    private LoseIntAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 0;
    public override string Description => "reduce intelligence";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        SaveGame.TakeHit(damage, monsterDescription);
        if (SaveGame.TryDecreasingAbilityScore(Ability.Intelligence))
        {
            obvious = true;
        }
    }
}