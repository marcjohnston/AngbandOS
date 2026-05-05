// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class RestorePack
{
    private int CurrentBitIndex = 0;
    private int CurrentIndex = 0;
    private byte[] Data;
    public RestorePack(byte[] data)
    {
        Data = data;
    }
    public bool UnpackBoolFromBit()
    {
        bool value = ((Data[CurrentIndex] >> CurrentBitIndex) & 1) == 1;
        CurrentBitIndex++;
        if (CurrentBitIndex > 7)
        {
            CurrentIndex++;
            CurrentBitIndex = 0;
        }
        return value;
    }

    public bool UnpackBool()
    {
        bool value = Data[CurrentIndex] == 1;
        CurrentIndex += 1;
        return value;
        
    }
    public int UnpackInt()
    {
        int value = BitConverter.ToInt32(Data, CurrentIndex);
        CurrentIndex += 4;
        return value;
    }
}
