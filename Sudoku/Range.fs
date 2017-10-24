﻿namespace Sudoku

open Digit

module Range=

    let VerticalRange  (x, _) =
        AllDigits |> List.map (fun item -> (x, item))|>
        Set.ofList

    let HorizontalRange (_, y) =
        AllDigits |> List.map (fun item -> (item, y))|>
        Set.ofList

    let NineRange (x, y) =
       let posToCenter x = 
        let center =
            match x with
             |Digits.One | Digits.Two | Digits.Three -> Digits.Two
             |Digits.Four | Digits.Five | Digits.Six -> Digits.Five
             |_ -> Digits.Seven
        int(center)

       let xPos = posToCenter x
       let yPos = posToCenter y

       let shifts = [-1; 0; -1]
       let result = 
        seq{ for xShift in shifts  do 
             for yShift in shifts do 
                yield (enum<Digits>(xPos + xShift), (enum<Digits>(yPos + yShift)))
        }
       Set.ofSeq result

    let CombineRanges pos =
        VerticalRange pos |>
        Set.union (HorizontalRange pos) |>
        Set.union (NineRange pos) |>
        Set.remove pos
            

    let AllRanges =
        let folder map pos =
            let ranges = CombineRanges pos
            Map.add pos ranges map 
        AllDigits2D |> List.fold folder  Map.empty 