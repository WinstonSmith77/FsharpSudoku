namespace Sudoku

open Digit
open Cell
open Board
open Range

module Solver=

    let private removePossibleValue possibleValues value =
         let newPossibleValues =  Set.remove value possibleValues
         match Set.count newPossibleValues with
         | 1 -> Known (Set.minElement newPossibleValues)
         | _ -> AnyOf newPossibleValues

    let private updateCellInRange map key value =
        let current = Map.find key map
        match current with
        | Known _ -> map
        | AnyOf possibleValues -> Map.add key (removePossibleValue possibleValues value)  map

    let private distributeKnownField map key value =
        let range = AllRanges.[key]
        Set.fold (fun map key -> updateCellInRange map key value) map range
        

    let private applyForEachCell map key value =
       match value with
       | Known value -> distributeKnownField map key value
       | AnyOf _ -> map

    let rec private solvCells cells =
        let newCells =  Map.fold applyForEachCell cells cells 
        if newCells <> cells then (solvCells newCells) else newCells

    let Solver board =
        {Cells = (solvCells board.Cells)}
