// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportSelf3xScript : Script, IScript, ICastSpellScript
{
    private TeleportSelf3xScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public void ExecuteScript()
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), Game.ExperienceLevel.IntValue * 3);
    }
    public string LearnedDetails => $"range {Game.ExperienceLevel.IntValue * 3}";
}
