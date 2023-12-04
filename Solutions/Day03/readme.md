# Day 3: Gear Ratios

I used RegEx for this one again, even though it's really the wrong choice.
It's possible to parse the entire input in a single pass by using a regex that can match either a part number or a symbol.
Then, you can derive the x/y position from the match index.

Unlike many solutions, I used a `Dictionary` instead of a 2D array.
This has one big advantage, which is that the data model is non-sparse.
Empty spaces simple don't exist at all, which increases the performance of "check all the neighbors" routines.

I also made a few improvements to the runner framework:
* Tweaked `csproj` files to avoid build errors when an input file is missing.
* Converted `Point` struct into a generic that can support any integer type.