namespace AdventOfCode.Common;

/// <summary>
/// Expected use case for an input file
/// </summary>
public enum InputFileType
{
    /// <summary>
    /// Standard input files from the AdventOfCode website.
    /// There should only be one of these per solution.
    /// </summary>
    Standard,
    
    /// <summary>
    /// Input files containing simpler or specific inputs for testing.
    /// </summary>
    Test,
    
    /// <summary>
    /// Challenge inputs to stress test a solution
    /// </summary>
    Challenge
}