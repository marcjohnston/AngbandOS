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
    public UpdateScentFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    private void UpdateFlowAux(int y, int x, int n)
    {
        int oldHead = _flowHead;
        GridTile cPtr = SaveGame.Grid[y][x];
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
        SaveGame.TempY[_flowHead] = y;
        SaveGame.TempX[_flowHead] = x;
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
        if (SaveGame.TempN != 0)
        {
            return;
        }
        if (_flowN == 255)
        {
            for (y = 0; y < SaveGame.CurHgt; y++)
            {
                for (x = 0; x < SaveGame.CurWid; x++)
                {
                    int w = SaveGame.Grid[y][x].ScentAge;
                    SaveGame.Grid[y][x].ScentAge = w > 128 ? w - 128 : 0;
                }
            }
            _flowN = 127;
        }
        _flowN++;
        _flowHead = 0;
        _flowTail = 0;
        UpdateFlowAux(SaveGame.MapY, SaveGame.MapX, 0);
        while (_flowHead != _flowTail)
        {
            y = SaveGame.TempY[_flowTail];
            x = SaveGame.TempX[_flowTail];
            if (++_flowTail == Constants.TempMax)
            {
                _flowTail = 0;
            }
            for (int d = 0; d < 8; d++)
            {
                UpdateFlowAux(y + SaveGame.OrderedDirectionYOffset[d], x + SaveGame.OrderedDirectionXOffset[d], SaveGame.Grid[y][x].ScentStrength + 1);
            }
        }
        _flowHead = 0;
        _flowTail = 0;
    }
}
