namespace Sudoku

module Digit=
  
    type Digits =
     | One = 1
     | Two = 2
     | Three = 3

     | Four = 4
     | Five = 5
     | Six = 6

     | Seven = 7
     | Eight = 8
     | Nine = 9

    let AllDigits = [1..9] |> List.map (fun i -> enum<Digits>(i)) 

    type Point =  Digits * Digits 
   
    let AllDigits2D = 
        seq{
          for x in AllDigits do 
           for y in AllDigits do
              yield (x, y)
           } |> List.ofSeq