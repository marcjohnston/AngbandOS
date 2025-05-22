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
        if (Game.ExperienceLevel.IntValue > 44)
        {
            Game.RunScript(nameof(LightScript));
        }
        else if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.RunScript(nameof(MapAreaScript));
        }
        bool isIdentified;
        if (Game.ExperienceLevel.IntValue < 30)
        {
            isIdentified = Game.RunIdentifiedScript(nameof(DetectNormalMonstersScript));
            if (Game.ExperienceLevel.IntValue > 14)
            {
                isIdentified |= Game.DetectInvisibleMonsters();
            }
            if (Game.ExperienceLevel.IntValue > 4)
            {
                isIdentified |= Game.DetectTraps();
            }
        }
        else
        {
            isIdentified = Game.RunIdentifiedScript(nameof(DetectionScript));
        }
        if (Game.ExperienceLevel.IntValue > 24 && Game.ExperienceLevel.IntValue < 40)
        {
            Game.TelepathyTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (!isIdentified)
        {
            Game.MsgPrint("You feel safe.");
        }
    }

    protected override string LearnedDetails()
    {
        return string.Empty;
    }
}