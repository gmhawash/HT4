Imports System.Web.Configuration
Imports System.Configuration
Imports System.Yaml
Imports System.Web.Hosting
Imports System.IO
Imports System.IO.Path

Module Helper
  ' FolderPath: @"Folder\Subfolder"
  Sub CreateFolder(ByVal FolderPath As String)
    Dim dirInfo As DirectoryInfo = New DirectoryInfo(FolderPath)
    If (Not Directory.Exists(FolderPath)) Then
      Directory.CreateDirectory(FolderPath)
    End If
  End Sub

  Sub DeleteFiles(ByVal Folder, ByVal filename)
    Dim files() = Directory.GetFiles(Folder, filename)

    For Each f In files
      File.Delete(f)
    Next
  End Sub


  Sub UploadFile(ByVal filename, ByVal inputStream)
    Dim writer As FileStream
    writer = System.IO.File.Open(filename, FileMode.Create, FileAccess.Write)
    Using inputStream
      Dim bufSize = 1024 * 1024
      Dim buff() As Byte = New Byte(bufSize) {}
      Dim count = 0

      Do
        count = inputStream.Read(buff, 0, bufSize)
        writer.Write(buff, 0, count)
      Loop While (count > 0)

      writer.Close()
    End Using
  End Sub
End Module
