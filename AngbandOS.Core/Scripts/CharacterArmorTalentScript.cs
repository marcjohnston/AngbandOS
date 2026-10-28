// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class CharacterArmorTalentScript : UniversalScript
{
    private CharacterArmorTalentScript(Game game) : base(game) { }
    public override void ExecuteScript()
    {
        Game.StoneskinTimer.AddTimer(Game.ExperienceLevel.IntValue);
        if (Game.ExperienceLevel.IntValue > 14)
        {
            Game.AcidResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.RunScript(nameof(FireResistance1xTimerScript));
        }
        if (Game.ExperienceLevel.IntValue > 24)
        {
            Game.ColdResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 29)
        {
            Game.LightningResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 34)
        {
            Game.PoisonResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
    }
}
