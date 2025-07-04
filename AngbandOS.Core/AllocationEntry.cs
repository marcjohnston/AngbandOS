// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core;

/// <summary>
/// An allocation entry for selecting monsters and items
/// </summary>
[Serializable]
internal class AllocationEntry
{
    /// <summary>
    /// The base probability of the entry being chosen
    /// </summary>
    public int BaseProbability;

    /// <summary>
    /// The probability of the entry being chosen, after first pass filtering
    /// </summary>
    public int FilteredProbabiity;

    /// <summary>
    /// The probability of the entry being chosen, after second pass filtering
    /// </summary>
    public int FinalProbability;

    /// <summary>
    /// The index of the monster or item that this entry is for
    /// </summary>
    public int Index;

    /// <summary>
    /// The level of the monster or item that this entry is for
    /// </summary>
    public int Level;
}