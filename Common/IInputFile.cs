
namespace AdventOfCode.Common;

/// <summary>
/// Defines an input file that can be loaded and passed to a solution.
/// </summary>
/// <remarks>
/// The relationship between input files and solutions is many-many.
/// Multiple inputs can be registered a single solution, and a single input can be registered to multiple solutions.
/// 
/// If multiple defaults are specified, then the one of them will be picked in an undefined manner.
/// If no defaults are specified, then any of type <see cref="InputFileType.Standard"/> will be picked in an undefined manner.
/// If no defaults are specified AND there are no standard inputs, then any available will be picked in an undefined manner.
/// If no inputs are specified and one cannot be selected from elsewhere (such as CLI arguments), then the solution will fail to run.
/// </remarks>
public interface IInputFile
{
    /// <summary>
    /// Path to the input file, relative to the working directory
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Type of input file
    /// </summary>
    InputFileType Type { get; }

    /// <summary>
    /// Optional human-readable name for this input file.
    /// Will be shown to the user and can be used as an identifier to select this input.
    /// Does not need to be unique, but cannot be used for identification if there are duplicates.
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// Optional human-readable description of this input file.
    /// Should be 1-3 sentences in length.
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// Specifies how <see cref="Path"/> should be resolved.
    /// </summary>
    InputFileResolution Resolution { get; }
    
    /// <summary>
    /// If true, then this input should be prioritized as a default.
    /// </summary>
    bool IsDefault { get; }
}