#Region "CaseInsensitiveDictionary - Implements a dictionary with string keys where the key is case insensistive."
''' <summary>
''' Implements a dictionary with string keys where the key is case insensistive.
''' </summary>
''' <typeparam name="t"></typeparam>
''' <remarks>
''' This class inherits from the Dictionary object, forces the key to be a string, and overrides the Add, ContainsKey, Item, Remove and TryGetValue methods.  The methods convert all references to the key to uppercase.  There is no option to use lowercase keys.
''' </remarks>
Public Class CaseInsensitiveDictionary(Of t)
    Inherits Dictionary(Of String, t)

#Region "Public Methods"
#Region "Add - Adds a new item to the dictionary.  The key is converted to uppercase."
    ''' <summary>
    ''' Adds a new item to the dictionary.  The key is converted to uppercase.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Shadows Sub Add(key As String, value As t)
        MyBase.Add(UCase(key), value)
    End Sub
#End Region
#Region "ContainsKey - Returns true, if the dictionary contains a specific key.  The key is converted to uppercase."
    ''' <summary>
    ''' Returns true, if the dictionary contains a specific key.  The key is converted to uppercase.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function ContainsKey(key As String) As Boolean
        Return MyBase.ContainsKey(UCase(key))
    End Function
#End Region
#Region "Item - Returns an item from the dictionary using the key.  The key is converted to uppercase."
    ''' <summary>
    ''' Returns an item from the dictionary using the key.  The key is converted to uppercase.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Default Public Shadows Property Item(key As String) As t
        Get
            Return MyBase.Item(UCase(key))
        End Get
        Set(ByVal value As t)
            MyBase.Item(UCase(key)) = value
        End Set
    End Property
#End Region
#Region "Remove - Removes an item from the dictionary, using the key to reference the item.  The key is converted to uppercase."
    ''' <summary>
    ''' Removes an item from the dictionary, using the key to reference the item.  The key is converted to uppercase.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function Remove(key As String) As Boolean
        Return MyBase.Remove(UCase(key))
    End Function
#End Region
#Region "TryGetValue - Returns true, if an item exists in the dictionary using the key to reference the item.  If the item exists, it sets a ByRef parameter to the object; otherwise false is returned.  The key is converted to uppercase."
    ''' <summary>
    ''' Returns true, if an item exists in the dictionary using the key to reference the item.  If the item exists, it sets a ByRef parameter to the object; otherwise false is returned.  The key is converted to uppercase.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function TryGetValue(key As String, ByRef value As t) As Boolean
        Return MyBase.TryGetValue(UCase(key), value)
    End Function
#End Region
#End Region

End Class
#End Region