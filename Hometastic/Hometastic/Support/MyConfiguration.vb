Imports System.Web.Configuration
Imports System.Configuration
Imports System.Yaml
Imports System.Web.Hosting

Module MyConfiguration
  Public RootPath = HostingEnvironment.ApplicationPhysicalPath
  Public Setting As YamlMapping
  Private ConfigFile = RootPath & "/Configuration.Yaml"
  Private AssetBase = "/hometast4/HometastInfo"

  Sub Load()
    Dim nodes() As YamlNode = YamlNode.FromYamlFile(ConfigFile)
    Dim yaml As YamlNode = nodes(0)
    Setting = CType(yaml, YamlMapping)("default")

    Dim serverName = System.Net.Dns.GetHostName()
    Dim serverSpecific As YamlMapping = CType(yaml, YamlMapping)(serverName)

    For Each key In serverSpecific.Keys
      Setting(key) = serverSpecific(key)
    Next
  End Sub

  Function PhysicalAssetPath(ByVal type As String, ByVal path As String, ByVal filename As String, ByVal extension As String) As String
    Select Case type
      Case "front-image"
        filename = filename & "_front_image"
    End Select
    Return String.Format("{0}/{1}.{2}", PhysicalAssetFolder(type, path), filename, extension)
  End Function

  Function PhysicalAssetFolder(ByVal type As String, ByVal path As String)
    Return String.Format("{0}/{1}", Setting("Hometast3Info").ToString().Trim(""""), AssetPath(type, path))
  End Function

  Function AssetPath(ByVal type As String, ByVal path As String) As String
    Select Case type
      Case "logo"
        path = String.Format("logos/{0}", path)
      Case "front-image"
        path = String.Format("logos/{0}", path)
      Case Else
        Throw New Exception("We should not be here")
    End Select
    Return path
  End Function

  Function AssetUrl(ByVal type As String, ByVal path As String, ByVal filename As String) As String
    Dim url

    Select Case type
      Case Else
        url = String.Format("{0}/{1}/{2}", AssetBase, AssetPath(type, path), filename)
    End Select

    Return url
  End Function
End Module
