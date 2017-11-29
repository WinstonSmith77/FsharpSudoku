namespace Sudoku

open Digit
open Cell
open Board
open Range
open Verifer

module Solver=

    let private removePossibleValue possibleValues value =
         let newPossibleValues =  Set.remove value possibleValues
         match List.ofSeq newPossibleValues with
         | [n] -> Known n
         | _ -> AnyOf newPossibleValues

    let private updateCellInRange map key value =
        let current = Map.find key map
        match current with
        | Known _ -> map
        | AnyOf possibleValues -> Map.add key (removePossibleValue possibleValues value)  map

    let private distributeKnownCellValue map key value =
        let range = AllCombinedNeighborRangesForCell.[key]
        Set.fold (fun map key -> updateCellInRange map key value) map range

    let private applyForEachCell map key value =
       match value with
       | Known value -> distributeKnownCellValue map key value
       | AnyOf _ -> map

    let rec private solveCells cells =
        let newCells =  Map.fold applyForEachCell cells cells 
        match newCells <> cells with
        | true -> solveCells newCells
        | false -> newCells

    let Solver board =
       let possibleResult = {Cells = (solveCells board.Cells)}
       match Verify possibleResult with
       |true -> Some possibleResult
       |false -> None
