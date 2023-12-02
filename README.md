# advent-of-code-2023

My solutions to the [2023 Advent of Code challenge](https://adventofcode.com/).
Once again, I'm also prioritizing readable code over compact or "magic" solutions.
Feedback and questions are welcome!

### Usage
* From Rider IDE:
  1. select one of the included run configurations and click "Run" or "Debug".
* From a terminal:
  1. Open a terminal and navigate to the solution root.
  2. Execute `dotnet run --configuration Release --project Runner -- <command> [options]`
     * Supported commands:
       * `list <what>` - list data from internal registries. `what` specifies what data to return and can be one of these options:
         * `solutions [day] [part]` - list available solutions. `day` and `part` both default to `all`.
         * `inputs [day] [part] [variant]` - list registered input files for a solution. `day`, `part`, and `variant` all default to `all`.
       * `run [day] [part] [variant] [options]` - run one or more solutions. `day` and `part` both default to `all`. `variant` defaults to null, which means no variants will be selected. Supports options:
         * `[--input {id | name | type}]` - select a registered input file to use. Use `list inputs` to show all options. Applies to all selected days/parts.
         * `[--custom-input path_to_input]` - specify an custom, external input file to use. Applies to all selected days/parts.
       * `bench [day] [part] [variant] [options]` - benchmark one or more solutions. Supports same options and defaults as `run`, and additionally supports:
         * `[--min-warmup-time time_in_ms]` - set the minimum time (in milliseconds) to run warmup rounds (default 2000ms).
         * `[--min-warmup-rounds num_rounds]` - set the minimum number of warmup rounds (default 10).
         * `[--min-sample-time time_in_ms]` - set the minimum time (in milliseconds) to run sampling (benchmark) rounds (default 10000ms).
         * `[--min-sample-rounds num_rounds]` - set the minimum number of sampling (benchmark) rounds (default 10).
         * `[--no-warmup]` - skip warmup rounds entirely. Useful when using an external profiler.
       * `--help [command]` - show help.
       * `--version` - show project version.
     * Options:
       * `--vebose` - Show verbose / debug output. Defaults to off.
     * Parameters:
       * `day` - should be in `Day##` format. Can also be the string `all` to select all days.
       * `part` - should be in `Part#` format. Can also be the string `all` to select all parts.
       * `variant` - format is day/part-specific. Can also be the string `all` to select all variants.
       * `path_to_input` - if set, overrides the input file. Path is resolved relative to the current working directory.
       * `command` - if set, shows detailed help about a specific command.

### Solutions
| Day                      | Part 1                                 | Part 2                                 | Name                                                  |
|--------------------------|----------------------------------------|----------------------------------------|-------------------------------------------------------|
| [Day01](Solutions/Day01) | [Part1](Solutions/Day01/Day01Part1.cs) | [Part2](Solutions/Day01/Day01Part2.cs) | [Trebuchet?!](https://adventofcode.com/2023/day/1)    |
| [Day01](Solutions/Day02) | [Part1](Solutions/Day02/Day02Part1.cs) | [Part2](Solutions/Day02/Day02Part2.cs) | [Cube Conundrum](https://adventofcode.com/2023/day/2) |

### Details
* Dotnet 7 is required to run the solutions.
* Project files are included for JetBrains Rider, but the solution should work in Visual Studio or with the dotnet command line.
* Solutions should run on any supported .NET platform.
