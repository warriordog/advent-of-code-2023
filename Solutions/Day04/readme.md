# Day 4: Scratchcards

This solution involves a lot of math, which is something that I'm not great at.
For part 1, it was simple - just raise 2 to the number of matches, minus one to translate from one-based to zero-based numeric systems.
This works well and was easy to figure out and write.
Part 2, however, was not so simple.

I immediately knew better than to try a naive approach for part 2.
While the problem certainly *can* be solved through simple iteration, the exponential growth was an immediate red flag.
To ensure that the solution completes in a timely manner, I added a "multiplier" variable that determines how many copies of the current card should be included.
I loop through the cards only once, incrementing and decrementing the multiplier as I go.
This took a lot of experimenting to figure out, and I lost several hours because I mistakenly placed the "drop" code before the "increment" block.
Oops.
[You can see my manual testing in this file.](notes.txt)