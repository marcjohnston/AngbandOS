// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EatRockActiveMutation : Mutation
{
    private EatRockActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(8, 12, Ability.Constitution, 18))
        {
            return;
        }
        if (!SaveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
        int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
        GridTile cPtr = SaveGame.Grid[y][x];
        if (SaveGame.GridPassable(y, x))
        {
            SaveGame.MsgPrint("You bite into thin air!");
            return;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            SaveGame.MsgPrint("Ouch!  This wall is harder than your teeth!");
            return;
        }
        if (cPtr.MonsterIndex != 0)
        {
            SaveGame.MsgPrint("There's something in the way!");
            return;
        }
        if (cPtr.FeatureType.IsTree)
        {
            SaveGame.MsgPrint("You don't like the woody taste!");
            return;
        }
        if (cPtr.FeatureType.IsClosedDoor || cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsRubble)
        {
            SaveGame.SetFood(SaveGame.Food + 3000);
        }
        else if (cPtr.FeatureType.IsVein)
        {
            SaveGame.SetFood(SaveGame.Food + 5000);
        }
        else
        {
            SaveGame.MsgPrint("This granite is very filling!");
            SaveGame.SetFood(SaveGame.Food + 10000);
        }
        SaveGame.WallToMud(dir);
        int oy = SaveGame.MapY;
        int ox = SaveGame.MapX;
        SaveGame.MapY = y;
        SaveGame.MapX = x;
        SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);
        SaveGame.RedrawSingleLocation(oy, ox);
        SaveGame.RecenterScreenAroundPlayer();
        base.SaveGame.SingletonRepository.FlaggedActions.Get<UpdateScentFlaggedAction>().Set();
        base.SaveGame.SingletonRepository.FlaggedActions.Get<UpdateLightFlaggedAction>().Set();
        base.SaveGame.SingletonRepository.FlaggedActions.Get<UpdateViewFlaggedAction>().Set();
        base.SaveGame.SingletonRepository.FlaggedActions.Get<UpdateDistancesFlaggedAction>().Set();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 8 ? "eat rock         (unusable until level 8)" : "eat rock         (cost 12, CON based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "The walls look delicious.";
    public override string HaveMessage => "You can consume solid rock.";
    public override string LoseMessage => "The walls look unappetizing.";
}