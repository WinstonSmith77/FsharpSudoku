namespace Sudoku

open Digit

module Range=
    let private lineRange lineCreator =
        Digit.AllDigits |> Set.map lineCreator

    let private verticalRange  (x, _) =
       lineRange (fun item -> (x, item))

    let private horizontalRange  (_, y) =
       lineRange (fun item -> (item, y))

    let private nineRange (x, y) =
       let posToCenter x = 
            match x with
            | Digit.One | Digit.Two | Digit.Three -> Digit.Two
            | Digit.Four | Digit.Five | Digit.Six -> Digit.Five
            | Digit.Seven | Digit.Eight | Digit.Nine -> Digit.Eight

       let xPos = posToCenter x
       let yPos = posToCenter y

       let shifts = [-1; 0; 1]
     
       seq{ for xShift in shifts  do 
              for yShift in shifts do 
                yield (xPos + xShift),  (yPos + yShift)
       }
       |>Set.ofSeq 

    let private combinedRangesForCell pos =
        verticalRange pos |>
        Set.union (horizontalRange pos) |>
        Set.union (nineRange pos) |>
        Set.remove pos

    let AllCombinedRangesForCell =
        let folder map pos =
            let ranges = combinedRangesForCell pos
            Map.add pos ranges map 
        Digit.AllDigits2D |> List.fold folder  Map.empty 

    let private rangesForCell pos =
        Set.empty |>
        Set.add (verticalRange pos) |>
        Set.add (horizontalRange pos) |>
        Set.add (nineRange pos) 

    let AllRanges =
        let folder set pos =
            let ranges = rangesForCell pos
            Set.union set ranges
        Digit.AllDigits2D |> List.fold folder Set.empty 