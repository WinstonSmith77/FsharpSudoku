namespace Sudoku

open Digit
open Cell
open Board
open Range

module Verifer=

    let private trueForAnyRange range cells =
        let values = Set.fold (fun set pos -> Set.add (Map.find pos cells) set) Set.empty range
        true

    let private verifyCells cells =
       Set.forall (fun range -> trueForAnyRange range cells) AllRanges 

    let Verify board =
        verifyCells board.Cells
