This project is made for Digiage Game Camp

This is a clone of an existing hypercasual runner game. 

Many of the features existed on the game has been cloned over here. 

I wouldn't claim that my solution is the best but I think it is a decent one nonetheless
Used editor version is 2021.3.16f1 LTS. Although I didn't use any extra packets. It might not be compatible with other versions. 

Basic game state is passed and saved with basic DTOs which contain almost all the stats. It should be noted that using DTOs like this might cause GC to overwork.
But it should be noted that levels are short so GC work is inevitable anyway.
