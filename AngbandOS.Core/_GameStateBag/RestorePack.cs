// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System;
using System.Text;

namespace AngbandOS.Core;

internal class RestorePack
{
    private int CurrentBitIndex = 0;
    private int CurrentIndex = 0;
    private byte[] Data;
    private readonly RestoreGameState RestoreGameState;
    public RestorePack(RestoreGameState restoreGameState, byte[] data)
    {
        RestoreGameState = restoreGameState;
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

    public byte UnpackByte()
    {
        return Data[CurrentIndex++];
    }

    public byte[] UnpackBytes(int length)
    {
        byte[] result = new byte[length];
        Array.Copy(Data, CurrentIndex, result, 0, length);
        CurrentIndex += length;
        return result;
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

    public string UnpackString()
    {
        byte[] byteArray = UnpackBytes(UnpackInt());
        string value = Convert.ToBase64String(byteArray);
        return value;
    }

    public GameStateBag UnpackGameStateBag()
    {
        string serializedGameStateBag = UnpackString();
        GameStateBag? gameStateBag = GameStateBag.Deserialize(serializedGameStateBag);
        if (gameStateBag is null)
        {
            throw new Exception("Deserialize fail.");
        }
        return gameStateBag;
    }

    public byte[][] UnpackList()
    {
        int length = UnpackInt();
        List<byte[]> list = new List<byte[]>();
        for (int i = 0; i < length; i++)
        {
            list.Add(UnpackBytes(UnpackInt()));
        }
        return list.ToArray();
    }

    public Dictionary<string, GameStateBag>? UnpackDictionary()
    {
        if (UnpackByte() == 0)
        {
            return null;
        }
        byte[][] list = UnpackList();
        Dictionary<string, GameStateBag> dictionary = new Dictionary<string, GameStateBag>();
        foreach (byte[] data in list)
        {
            dictionary.Add(UnpackString(), UnpackGameStateBag());
        }
        return dictionary;
    }

    public T Unpack<T>() where T : IGameSerialize
    {
        // Check to see if this is a reference.
        if (UnpackByte() == 11)
        {
            // It is.
            int existingObjectId = UnpackInt();
            object reference = RestoreGameState.GetObjectById(existingObjectId);
            if (reference is T typedReference)
            {
                return typedReference;
            }
            throw new Exception("Cannot convert pack.");
        }
        int newObjectId = UnpackInt();
        string typeName = UnpackString();
        Dictionary<string, GameStateBag>? dictionary = null;
        if (UnpackByte() != 0)
        {
            dictionary = new Dictionary<string, GameStateBag>();
            int dictionaryLength = UnpackInt();
            for (int i = 0; i < dictionaryLength; i++)
            {
                string key = UnpackString();
                string serializedGameStateBag = UnpackString();
                GameStateBag? gameStateBag = GameStateBag.Deserialize(serializedGameStateBag);
                if (gameStateBag is null)
                {
                    throw new Exception("Deserialize failed.");
                }

                dictionary.Add(key, gameStateBag);
            }
        }
        ObjectGameStateBag objectGameStateBag = new ObjectGameStateBag(newObjectId, typeName, dictionary);

        object? existingObject = RestoreGameState.TryGetObjectById(newObjectId);
        if (existingObject is not null)
        {
            RestoreGameState.TrackGameStateBag(newObjectId, objectGameStateBag);
            T typedReference = (T)existingObject;
            return typedReference;
        }
        return RestoreGameState.CreateObject<T>(newObjectId, objectGameStateBag);
    }
}
