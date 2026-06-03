// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BlindnessMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private BlindnessMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        if (Game.HasBlindnessResistance)
        {
            Game.MsgPrint("You are unaffected!");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.BlindnessTimer.SetTimer(12 + base.Game.RandomLessThan(4));
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(BlindSpellResistantDetection)));
    }
}
