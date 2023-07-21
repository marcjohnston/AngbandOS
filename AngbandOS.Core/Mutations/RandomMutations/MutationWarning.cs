// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationWarning : Mutation
{
    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "You suddenly feel paranoid.";
        HaveMessage = "You receive warnings about your foes.";
        LoseMessage = "You no longer feel paranoid.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(1000) != 1)
        {
            return;
        }
        int dangerAmount = 0;
        for (int monster = 0; monster < saveGame.Level.MMax; monster++)
        {
            Monster mPtr = saveGame.Level.Monsters[monster];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Level >= saveGame.Player.ExperienceLevel)
            {
                dangerAmount += rPtr.Level - saveGame.Player.ExperienceLevel + 1;
            }
        }
        if (dangerAmount > 100)
        {
            saveGame.MsgPrint("You feel utterly terrified!");
        }
        else if (dangerAmount > 50)
        {
            saveGame.MsgPrint("You feel terrified!");
        }
        else if (dangerAmount > 20)
        {
            saveGame.MsgPrint("You feel very worried!");
        }
        else if (dangerAmount > 10)
        {
            saveGame.MsgPrint("You feel paranoid!");
        }
        else if (dangerAmount > 5)
        {
            saveGame.MsgPrint("You feel almost safe.");
        }
        else
        {
            saveGame.MsgPrint("You feel lonely.");
        }
    }
}