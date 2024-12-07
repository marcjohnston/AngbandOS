// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateScentFlaggedAction : FlaggedAction
{
    private int _flowHead;
    private int _flowN;
    private int _flowTail;
    private UpdateScentFlaggedAction(Game game) : base(game) { }
    private void UpdateFlowAux(int y, int x, int n)
    {
        int oldHead = _flowHead;
        GridTile cPtr = Game.Map.Grid[y][x];
        if (cPtr.ScentAge == _flowN)
        {
            return;
        }
        if (cPtr.FeatureType.BlocksScent)
        {
            return;
        }
        cPtr.ScentAge = _flowN;
        cPtr.ScentStrength = n;
        if (n == Constants.MonsterFlowDepth)
        {
            return;
        }
        Game.TempY[_flowHead] = y;
        Game.TempX[_flowHead] = x;
        if (++_flowHead == Constants.TempMax)
        {
            _flowHead = 0;
        }
        if (_flowHead == _flowTail)
        {
            _flowHead = oldHead;
        }
    }

    protected override void Execute()
    {
        int x, y;
        if (Game.TempN != 0)
        {
            return;
        }
        if (_flowN == 255)
        {
            for (y = 0; y < Game.CurHgt; y++)
            {
                for (x = 0; x < Game.CurWid; x++)
                {
                    int w = Game.Map.Grid[y][x].ScentAge;
                    Game.Map.Grid[y][x].ScentAge = w > 128 ? w - 128 : 0;
                }
            }
            _flowN = 127;
        }
        _flowN++;
        _flowHead = 0;
        _flowTail = 0;
        UpdateFlowAux(Game.MapY.IntValue, Game.MapX.IntValue, 0);
        while (_flowHead != _flowTail)
        {
            y = Game.TempY[_flowTail];
            x = Game.TempX[_flowTail];
            if (++_flowTail == Constants.TempMax)
            {
                _flowTail = 0;
            }
            for (int d = 0; d < 8; d++)
            {
                UpdateFlowAux(y + Game.OrderedDirectionYOffset[d], x + Game.OrderedDirectionXOffset[d], Game.Map.Grid[y][x].ScentStrength + 1);
            }
        }
        _flowHead = 0;
        _flowTail = 0;
    }
}
