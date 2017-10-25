namespace Sudoku

open Digit

module Range=

    let private VerticalRange  (x, _) =
        Digits.AllDigits |> List.map (fun item -> (x, item))|>
        Set.ofList

    let private HorizontalRange (_, y) =
        Digits.AllDigits |> List.map (fun item -> (item, y))|>
        Set.ofList

    let private NineRange (x, y) =
       let posToCenter x = 
        let center =
            match x with
             |Digits.One | Digits.Two | Digits.Three -> Digits.Two
             |Digits.Four | Digits.Five | Digits.Six -> Digits.Five
             |Digits.Seven | Digits.Eight | Digits.Nine -> Digits.Eight
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

    let private CombineRanges pos =
        VerticalRange pos |>
        Set.union (HorizontalRange pos) |>
        Set.union (NineRange pos) |>
        Set.remove pos
            

    let AllCombinedRanges =
        let folder map pos =
            let ranges = CombineRanges pos
            Map.add pos ranges map 
        Digits.AllDigits2D |> List.fold folder  Map.empty 