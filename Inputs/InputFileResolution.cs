namespace AdventOfCode.Inputs;

/// <summary>
/// Determines how the input file should be located.
/// </summary>
public enum InputFileResolution
{
    /// <summary>
    /// Input file should be resolved as a filesystem path relative to the current working directory.
    /// </summary>
    PathRelative,

    /// <summary>
    /// Input file should be resolved as an absolute filesystem path
    /// </summary>
    PathAbsolute,

    /// <summary>
    /// Input file should be resolved as an <a href="https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getmanifestresourcestream?view=net-7.0#system-reflection-assembly-getmanifestresourcestream(system-type-system-string)">embedded resource scoped to the solution class</a>.
    /// </summary>
    /// <remarks>
    /// To use, the file should be located in a directory structure matching the namespace of the solution.
    /// The filename should not include the path.
    /// Example: "input.txt"
    /// </remarks>
    EmbeddedResource,

    /// <summary>
    /// Input file should be resolved as an <a href="https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getmanifestresourcestream?view=net-7.0#system-reflection-assembly-getmanifestresourcestream(system-string)">unscoped embedded resource</a>.
    /// </summary>
    /// <remarks>
    /// To use, the filename should be the path to file separated by dots, followed by the filename
    /// Example: "AdventOfCode.Inputs.some_input.txt"
    /// </remarks>
    EmbeddedResourceAbsolute,
    
    /// <summary>
    /// Input file should be resolved by looking up the entry in the Inputs projects.
    /// </summary>
    Named
}

public static class InputFileResolutionExtensions
{
    public static bool IsEmbedded(this InputFileResolution resolution) => resolution switch
    {
        InputFileResolution.EmbeddedResource => true,
        InputFileResolution.EmbeddedResourceAbsolute => true,
        _ => false
    };

    public static bool IsRelativeToCWD(this InputFileResolution resolution)
        => resolution == InputFileResolution.PathRelative; 
    
    public static bool IsExternal(this InputFileResolution resolution) => resolution switch
    {
        InputFileResolution.PathRelative => true,
        InputFileResolution.PathAbsolute => true,
        _ => false
    };
}