// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.RenderMessageScripts;
namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class LoseConChestTrap : ChestTrap
{
    private LoseConChestTrap(Game game) : base(game) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        Game.RunScript(nameof(ASmallNeedleHasPrickedYouRenderMessageScript));
        Game.TakeHit(Game.DiceRoll(1, 4), "a poison needle");
        Game.TryDecreasingAbilityScore(Game.ConstitutionAbility);
    }
    public override string Description => "(Poison Needle)";
}
