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
    private PrecognitionTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Precognition";
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;

    public override void Use()
    {
        if (SaveGame.ExperienceLevel > 44)
        {
            SaveGame.RunScript(nameof(LightScript));
        }
        else if (SaveGame.ExperienceLevel > 19)
        {
            SaveGame.RunScript(nameof(MapAreaScript));
        }
        bool b;
        if (SaveGame.ExperienceLevel < 30)
        {
            b = SaveGame.RunSuccessfulScript(nameof(DetectNormalMonstersScript));
            if (SaveGame.ExperienceLevel > 14)
            {
                b |= SaveGame.DetectMonstersInvis();
            }
            if (SaveGame.ExperienceLevel > 4)
            {
                b |= SaveGame.DetectTraps();
            }
        }
        else
        {
            b = SaveGame.RunSuccessfulScript(nameof(DetectionScript));
        }
        if (SaveGame.ExperienceLevel > 24 && SaveGame.ExperienceLevel < 40)
        {
            SaveGame.TelepathyTimer.AddTimer(SaveGame.ExperienceLevel);
        }
        if (!b)
        {
            SaveGame.MsgPrint("You feel safe.");
        }
    }

    protected override string Comment()
    {
        return string.Empty;
    }
}