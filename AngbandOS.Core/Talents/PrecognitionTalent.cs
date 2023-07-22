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
    public override void Initialize(int characterClass)
    {
        Level = 1;
        ManaCost = 1;
        BaseFailure = 15;
    }

    public override void Use()
    {
        if (SaveGame.Player.ExperienceLevel > 44)
        {
            SaveGame.Level.WizLight();
        }
        else if (SaveGame.Player.ExperienceLevel > 19)
        {
            SaveGame.Level.MapArea();
        }
        bool b;
        if (SaveGame.Player.ExperienceLevel < 30)
        {
            b = SaveGame.DetectMonstersNormal();
            if (SaveGame.Player.ExperienceLevel > 14)
            {
                b |= SaveGame.DetectMonstersInvis();
            }
            if (SaveGame.Player.ExperienceLevel > 4)
            {
                b |= SaveGame.DetectTraps();
            }
        }
        else
        {
            b = SaveGame.DetectAll();
        }
        if (SaveGame.Player.ExperienceLevel > 24 && SaveGame.Player.ExperienceLevel < 40)
        {
            SaveGame.Player.TimedTelepathy.AddTimer(SaveGame.Player.ExperienceLevel);
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