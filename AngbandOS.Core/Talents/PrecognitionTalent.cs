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

    public override void Use(SaveGame saveGame)
    {
        if (saveGame.Player.ExperienceLevel > 44)
        {
            saveGame.Level.WizLight();
        }
        else if (saveGame.Player.ExperienceLevel > 19)
        {
            saveGame.Level.MapArea();
        }
        bool b;
        if (saveGame.Player.ExperienceLevel < 30)
        {
            b = saveGame.DetectMonstersNormal();
            if (saveGame.Player.ExperienceLevel > 14)
            {
                b |= saveGame.DetectMonstersInvis();
            }
            if (saveGame.Player.ExperienceLevel > 4)
            {
                b |= saveGame.DetectTraps();
            }
        }
        else
        {
            b = saveGame.DetectAll();
        }
        if (saveGame.Player.ExperienceLevel > 24 && saveGame.Player.ExperienceLevel < 40)
        {
            saveGame.Player.TimedTelepathy.AddTimer(saveGame.Player.ExperienceLevel);
        }
        if (!b)
        {
            saveGame.MsgPrint("You feel safe.");
        }
    }

    protected override string Comment(Player player)
    {
        return string.Empty;
    }
}