using System.Text.RegularExpressions;
using AdventOfCode.Util;
using AdventOfCode.Inputs;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Solutions.Day01;

[InputFile(NamedInputs.Day01)]
[InputFile(NamedInputs.Day01Test1, InputFileType.Test)]
[InputFile(NamedInputs.Day01Test2, InputFileType.Test)]
[InputFile(NamedInputs.Day01Test3, InputFileType.Test)]
public abstract class Day01 : ISolution
{
    private readonly ILogger _logger;
    protected Day01(ILogger logger) => _logger = logger;
    public void Run(string inputFile)
    {
        var calibrationSum = GetCalibrationSum(inputFile);
        _logger.LogInformation("The sum of all of the calibration values is [{calibrationSum}].", calibrationSum);
    }

    private int GetCalibrationSum(string inputFile)
        => inputFile
            .SplitByEOL()
            .SkipEmptyStrings()
            .Select(GetLineValue)
            .Aggregate(0, (value, sum) => value + sum);

    protected abstract int GetLineValue(string line);
} 