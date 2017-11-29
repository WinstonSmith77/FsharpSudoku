namespace Sudoku

open Digit

module Range=
    let private lineRange lineCreator =
        Digit.AllDigits |> Set.map lineCreator

    let private verticalRange  (x, _) =
       lineRange (fun i -> (x, i))

    let private horizontalRange  (_, y) =
       lineRange (fun i -> (i, y))

    let private nineRange (x, y) =
       let posToCenter x = 
            match x with
            | Digit.One | Digit.Two | Digit.Three -> Digit.Two
            | Digit.Four | Digit.Five | Digit.Six -> Digit.Five
            | Digit.Seven | Digit.Eight | Digit.Nine -> Digit.Eight

       let xPos = posToCenter x
       let yPos = posToCenter y

       let shifts = [-1; 0; 1]

       shifts |> 
       List.collect (fun xShift -> shifts |> List.map (fun yShift -> (xPos + xShift),  (yPos + yShift))) 
       |> Set.ofList

       //seq{ for xShift in shifts  do 
       //       for yShift in shifts do 
       //         yield 
       //}
       //|>Set.ofSeq 
     
      

    let private combinedNeighborRangesForCell pos =
        verticalRange pos |>
        Set.union (horizontalRange pos) |>
        Set.union (nineRange pos) |>
        Set.remove pos

    let AllCombinedNeighborRangesForCell =
        Digit.AllDigits2D |> List.fold (fun map pos -> Map.add pos (combinedNeighborRangesForCell pos) map)  Map.empty 

    let private rangesForCell pos =
        Set.empty |>
        Set.add (verticalRange pos) |>
        Set.add (horizontalRange pos) |>
        Set.add (nineRange pos) 

    let AllRanges =
        Digit.AllDigits2D |> List.fold (fun set pos ->  Set.union set (rangesForCell pos)) Set.empty 