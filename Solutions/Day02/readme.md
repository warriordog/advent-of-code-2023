# Day 2: Cube Conundrum

I totally over-prepared for this one.
After yesterday's surprise in part two, I tried to think through all the different directions that part two could go.
I landed on statistical analysis of the cubes in the bag, with the goal being to correctly guess the exact number.

My solution for part one ended up being over-complicated in preparation for this.
I built out a framework of custom types and functions to progressively narrow the "range" of various stats, and then ended up removing most of it when it was simply unused.
The only part I kept was "minimum possible value", which ended up being the only data needed to solve both parts of the problem!

---

Dear diary,
Today I discovered that DotNet contains a Sum function that can be called on `IEnumerable` of any numeric type. 
For my entire career, I've been writing out `.Aggregate(0, (sum, value) => sum + value)` like a complete dumb-ass when I could have just used `.Sum()`.
They should take away my degree - clearly I don't deserve it!
