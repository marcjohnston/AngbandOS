nuget pack 
copy byMarc.Net2.Library.Collections.CaseInsensitiveDictionary.2017.811.0.nupkg D:\OneDrive\ESTC\NuGet

del byMarc.Net2.Library.Collections.CaseInsensitiveDictionary.2017.811.0.zip
"C:\Program Files\7-Zip\7z.exe" a -i@listfile.txt byMarc.Net2.Library.Collections.CaseInsensitiveDictionary.2017.811.0.zip -mem=AES256
pause