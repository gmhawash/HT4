Imports System.Web.Configuration
Imports System.Configuration
Imports System.Yaml
Imports System.Web.Hosting

Module MyConfiguration
  Public RootPath = HostingEnvironment.ApplicationPhysicalPath
  Public Setting As YamlMapping
  Private ConfigFile = RootPath & "/Configuration.Yaml"

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
End Module
