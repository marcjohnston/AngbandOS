// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellSummonReptiles : Spell
{
    private TarotSpellSummonReptiles(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.MsgPrint("You concentrate on the image of a reptile...");
        if (Program.Rng.DieRoll(5) > 2)
        {
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.Level, new HydraMonsterSelector(), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.Level, new HydraMonsterSelector()))
        {
            SaveGame.MsgPrint("The summoned reptile gets angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Summon Reptiles";
    
    protected override string? Info()
    {
        return "control 60%";
    }
}