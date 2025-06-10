// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EvocationScript : Script, IScript, ICastSpellScript
{
    private EvocationScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Displels, turns and banishs monsters with damage of the player experience * 4.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(DispelAllAtLos4xProjectileScript));
        Game.RunScript(nameof(TurnAllAtLos4xProjectileScript));
        Game.RunScriptInt(nameof(TeleportAwayAllAtLos4xProjectileScript), Game.ExperienceLevel.IntValue * 4);
    }
    public string LearnedDetails => $"dam {Game.ExperienceLevel.IntValue * 4}";
}
