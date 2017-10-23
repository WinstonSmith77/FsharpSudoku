namespace Sudoku

open System.Collections.Generic

open Cell
open Digit

module Board =
    type Board= {
         Cells : Map<Point, Cell>
        }

    let EmptyBoard = {Cells = AllDigits2D |> List.fold (fun acc x -> Map.add x (Cell.UnKnown Set.empty) acc) Map.empty}
