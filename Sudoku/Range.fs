namespace Sudoku

open Digit

module Range=

    let private verticalRange  (x, _) =
        Digits.AllDigits |> List.map (fun item -> (x, item))|>
        Set.ofList

    let private horizontalRange (_, y) =
        Digits.AllDigits |> List.map (fun item -> (item, y))|>
        Set.ofList

    let private nineRange (x, y) =
       let posToCenter x = 
        let center =
            match x with
             | Digits.One | Digits.Two | Digits.Three -> Digits.Two
             | Digits.Four | Digits.Five | Digits.Six -> Digits.Five
             | Digits.Seven | Digits.Eight | Digits.Nine -> Digits.Eight
        center.ToInt

       let xPos = posToCenter x
       let yPos = posToCenter y

       let shifts = [-1; 0; 1]
       let result = 
        seq{ for xShift in shifts  do 
              for yShift in shifts do 
                yield Digits.ToDigit (xPos + xShift),  Digits.ToDigit (yPos + yShift)
        }
       Set.ofSeq result

    let private combinedRangesForCell pos =
        verticalRange pos |>
        Set.union (horizontalRange pos) |>
        Set.union (nineRange pos) |>
        Set.remove pos

    let AllCombinedRangesForCell =
        let folder map pos =
            let ranges = combinedRangesForCell pos
            Map.add pos ranges map 
        Digits.AllDigits2D |> List.fold folder  Map.empty 

    let private rangesForCell pos =
        Set.empty |>
        Set.add (verticalRange pos) |>
        Set.add (horizontalRange pos) |>
        Set.add (nineRange pos) 

    let AllRanges =
        let folder set pos =
            let ranges = rangesForCell pos
            Set.union set ranges
        Digits.AllDigits2D |> List.fold folder Set.empty 