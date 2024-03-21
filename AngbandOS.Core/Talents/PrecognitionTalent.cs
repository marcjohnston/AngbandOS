// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PrecognitionTalent : Talent
{
    private PrecognitionTalent(Game game) : base(game) { }
    public override string Name => "Precognition";
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;

    public override void Use()
    {
        if (Game.ExperienceLevel.Value > 44)
        {
            Game.RunScript(nameof(LightScript));
        }
        else if (Game.ExperienceLevel.Value > 19)
        {
            Game.RunScript(nameof(MapAreaScript));
        }
        bool b;
        if (Game.ExperienceLevel.Value < 30)
        {
            b = Game.RunSuccessfulScript(nameof(DetectNormalMonstersScript));
            if (Game.ExperienceLevel.Value > 14)
            {
                b |= Game.DetectMonstersInvis();
            }
            if (Game.ExperienceLevel.Value > 4)
            {
                b |= Game.DetectTraps();
            }
        }
        else
        {
            b = Game.RunSuccessfulScript(nameof(DetectionScript));
        }
        if (Game.ExperienceLevel.Value > 24 && Game.ExperienceLevel.Value < 40)
        {
            Game.TelepathyTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        if (!b)
        {
            Game.MsgPrint("You feel safe.");
        }
    }

    protected override string Comment()
    {
        return string.Empty;
    }
}