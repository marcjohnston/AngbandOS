// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class ConfuseMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private ConfuseMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        if (Game.HasConfusionResistance)
        {
            Game.MsgPrint("You disbelieve the feeble spell.");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You disbelieve the feeble spell.");
        }
        else
        {
            Game.ConfusionTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ConfSpellResistantDetection)));
    }
}
