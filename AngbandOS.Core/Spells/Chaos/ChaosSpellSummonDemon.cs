// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellSummonDemon : Spell
{
    private ChaosSpellSummonDemon(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (Program.Rng.DieRoll(3) == 1)
        {
            if (SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.Level * 3 / 2, new DemonMonsterSelector()))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.Level * 3 / 2, new DemonMonsterSelector(), SaveGame.Player.Level == 50))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'What is thy bidding... Master?'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(23);
    }

    public override string Name => "Summon Demon";
    
    protected override string? Info()
    {
        return "control 67%";
    }
}