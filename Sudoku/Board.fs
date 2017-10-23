namespace Sudoku

open Cell
open Digit

module Board =
    type Board= {
         Cells : Map<Point, Cell>
                } 
     with 
         static member Empty = 
            {Cells = AllDigits2D |> List.fold (fun acc x -> Map.add x (Cell.UnKnown Set.empty) acc) Map.empty}
