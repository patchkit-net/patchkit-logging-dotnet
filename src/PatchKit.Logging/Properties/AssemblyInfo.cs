using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PatchKit.Logging")]
[assembly: AssemblyDescription("Shared library with standarized interfaces for creating application logs.")]
[assembly: AssemblyCompany("Upsoft")]
[assembly: AssemblyProduct("PatchKit.Logging")]
[assembly: AssemblyCopyright("Copyright © Upsoft 2018")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

#if DEBUG
[assembly: AssemblyVersion(VersionInfo.Major + "." + VersionInfo.Minor + ".*")]
#else
[assembly: AssemblyInformationalVersion(VersionInfo.Major + "." + VersionInfo.Minor + "." + VersionInfo.Patch + VersionInfo.Suffix)]
#endif