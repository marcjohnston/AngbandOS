// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationEatRock : Mutation
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
        int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
        int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
        GridTile cPtr = saveGame.Level.Grid[y][x];
        if (saveGame.Level.GridPassable(y, x))
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
        if (cPtr.FeatureType.Category.CategoryEnum == FloorTileTypeCategory.Tree)
        {
            saveGame.MsgPrint("You don't like the woody taste!");
            return;
        }
        if (cPtr.FeatureType.IsClosedDoor || cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsRubble)
        {
            saveGame.Player.SetFood(saveGame.Player.Food + 3000);
        }
        else if (cPtr.FeatureType.Category.CategoryEnum == FloorTileTypeCategory.Vein)
        {
            saveGame.Player.SetFood(saveGame.Player.Food + 5000);
        }
        else
        {
            saveGame.MsgPrint("This granite is very filling!");
            saveGame.Player.SetFood(saveGame.Player.Food + 10000);
        }
        saveGame.WallToMud(dir);
        int oy = saveGame.Player.MapY;
        int ox = saveGame.Player.MapX;
        saveGame.Player.MapY = y;
        saveGame.Player.MapX = x;
        saveGame.Level.RedrawSingleLocation(saveGame.Player.MapY, saveGame.Player.MapX);
        saveGame.Level.RedrawSingleLocation(oy, ox);
        saveGame.Player.RecenterScreenAroundPlayer();
        saveGame.UpdateScentFlaggedAction.Set();
        saveGame.UpdateLightFlaggedAction.Set();
        saveGame.UpdateViewFlaggedAction.Set();
        saveGame.UpdateDistancesFlaggedAction.Set();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 8 ? "eat rock         (unusable until level 8)" : "eat rock         (cost 12, CON based)";
    }

    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "The walls look delicious.";
        HaveMessage = "You can consume solid rock.";
        LoseMessage = "The walls look unappetizing.";
    }
}