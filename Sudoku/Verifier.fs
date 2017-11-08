namespace Sudoku

open Digit
open Cell
open Board
open Range

module Verifer=

    let private areAllDigitsInCellValues cellvalues  =
         let rec areAllDigitsInCellValuesInner values digits  =
            match values with
            | [] -> false
            | head::tail->
                match head with
                | Known digit -> 
                        let newDigits = Set.add digit digits
                        match tail with   
                             | [] -> newDigits = Digit.AllDigits
                             | tail -> areAllDigitsInCellValuesInner tail newDigits
                | AnyOf _ -> false
         areAllDigitsInCellValuesInner (List.ofSeq cellvalues)  Set.empty    

    let private trueForAnyRange range cells =
        let rangeCellValues = Set.fold (fun set pos -> Set.add (Map.find pos cells) set) Set.empty range
        areAllDigitsInCellValues rangeCellValues

    let private verifyCells cells =
        Set.forall (fun range -> trueForAnyRange range cells) AllRanges 

    let Verify board =
        verifyCells board.Cells
