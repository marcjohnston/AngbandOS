// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellTheFool : Spell
{
    private TarotSpellTheFool(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        MonsterSelector? summonType = null;
        SaveGame.MsgPrint("You concentrate on the Fool card...");
        switch (Program.Rng.DieRoll(4))
        {
            case 1:
                summonType = new Bizarre1MonsterSelector();
                break;

            case 2:
                summonType = new Bizarre2MonsterSelector();
                break;

            case 3:
                summonType = new Bizarre4MonsterSelector();
                break;

            case 4:
                summonType = new Bizarre5MonsterSelector();
                break;
        }
        if (Program.Rng.DieRoll(2) == 1)
        {
            SaveGame.MsgPrint(SaveGame.Level.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, summonType)
                ? "The summoned creature gets angry!"
                : "No-one ever turns up.");
        }
        else
        {
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, summonType, false))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }

    public override string Name => "The Fool";
    
    protected override string? Info()
    {
        return "control 50%";
    }
}