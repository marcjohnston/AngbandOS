﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EatRockActiveMutation : Mutation
{
    private EatRockActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(8, 12, Ability.Constitution, 18))
        {
            return;
        }
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY.Value + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX.Value + Game.KeypadDirectionXOffset[dir];
        GridTile cPtr = Game.Map.Grid[y][x];
        if (Game.GridPassable(y, x))
        {
            Game.MsgPrint("You bite into thin air!");
            return;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            Game.MsgPrint("Ouch!  This wall is harder than your teeth!");
            return;
        }
        if (cPtr.MonsterIndex != 0)
        {
            Game.MsgPrint("There's something in the way!");
            return;
        }
        if (cPtr.FeatureType.IsTree)
        {
            Game.MsgPrint("You don't like the woody taste!");
            return;
        }
        if (cPtr.FeatureType.IsVisibleDoor || cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsRubble)
        {
            Game.SetFood(Game.Food.Value + 3000);
        }
        else if (cPtr.FeatureType.IsVein)
        {
            Game.SetFood(Game.Food.Value + 5000);
        }
        else
        {
            Game.MsgPrint("This granite is very filling!");
            Game.SetFood(Game.Food.Value + 10000);
        }
        Game.WallToMud(dir);
        int oy = Game.MapY.Value;
        int ox = Game.MapX.Value;
        Game.MapY.Value = y;
        Game.MapX.Value = x;
        Game.MainForm.RefreshMapLocation(Game.MapY.Value, Game.MapX.Value);
        Game.MainForm.RefreshMapLocation(oy, ox);
        Game.RecenterScreenAroundPlayer();
        base.Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateScentFlaggedAction)).Set();
        base.Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        base.Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        base.Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateDistancesFlaggedAction)).Set();
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