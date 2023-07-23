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
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(8, 12, Ability.Constitution, 18))
        {
            return;
        }
        if (!saveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = saveGame.MapY + saveGame.KeypadDirectionYOffset[dir];
        int x = saveGame.MapX + saveGame.KeypadDirectionXOffset[dir];
        GridTile cPtr = saveGame.Grid[y][x];
        if (saveGame.GridPassable(y, x))
        {
            saveGame.MsgPrint("You bite into thin air!");
            return;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            saveGame.MsgPrint("Ouch!  This wall is harder than your teeth!");
            return;
        }
        if (cPtr.MonsterIndex != 0)
        {
            saveGame.MsgPrint("There's something in the way!");
            return;
        }
        if (cPtr.FeatureType.IsTree)
        {
            saveGame.MsgPrint("You don't like the woody taste!");
            return;
        }
        if (cPtr.FeatureType.IsClosedDoor || cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsRubble)
        {
            saveGame.SetFood(saveGame.Food + 3000);
        }
        else if (cPtr.FeatureType.IsVein)
        {
            saveGame.SetFood(saveGame.Food + 5000);
        }
        else
        {
            saveGame.MsgPrint("This granite is very filling!");
            saveGame.SetFood(saveGame.Food + 10000);
        }
        saveGame.WallToMud(dir);
        int oy = saveGame.MapY;
        int ox = saveGame.MapX;
        saveGame.MapY = y;
        saveGame.MapX = x;
        saveGame.RedrawSingleLocation(saveGame.MapY, saveGame.MapX);
        saveGame.RedrawSingleLocation(oy, ox);
        saveGame.RecenterScreenAroundPlayer();
        saveGame.UpdateScentFlaggedAction.Set();
        saveGame.UpdateLightFlaggedAction.Set();
        saveGame.UpdateViewFlaggedAction.Set();
        saveGame.UpdateDistancesFlaggedAction.Set();
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