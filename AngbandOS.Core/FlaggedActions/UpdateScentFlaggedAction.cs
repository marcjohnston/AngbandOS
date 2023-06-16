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
        GridTile cPtr = SaveGame.Level.Grid[y][x];
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
        SaveGame.Level.TempY[_flowHead] = y;
        SaveGame.Level.TempX[_flowHead] = x;
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
        if (SaveGame.Level.TempN != 0)
        {
            return;
        }
        if (_flowN == 255)
        {
            for (y = 0; y < SaveGame.Level.CurHgt; y++)
            {
                for (x = 0; x < SaveGame.Level.CurWid; x++)
                {
                    int w = SaveGame.Level.Grid[y][x].ScentAge;
                    SaveGame.Level.Grid[y][x].ScentAge = w > 128 ? w - 128 : 0;
                }
            }
            _flowN = 127;
        }
        _flowN++;
        _flowHead = 0;
        _flowTail = 0;
        UpdateFlowAux(SaveGame.Player.MapY, SaveGame.Player.MapX, 0);
        while (_flowHead != _flowTail)
        {
            y = SaveGame.Level.TempY[_flowTail];
            x = SaveGame.Level.TempX[_flowTail];
            if (++_flowTail == Constants.TempMax)
            {
                _flowTail = 0;
            }
            for (int d = 0; d < 8; d++)
            {
                UpdateFlowAux(y + SaveGame.Level.OrderedDirectionYOffset[d], x + SaveGame.Level.OrderedDirectionXOffset[d], SaveGame.Level.Grid[y][x].ScentStrength + 1);
            }
        }
        _flowHead = 0;
        _flowTail = 0;
    }
}
