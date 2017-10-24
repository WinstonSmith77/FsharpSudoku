namespace Sudoku

open Cell
open Digit

module Board =
    type Board= {
         Cells : Map<Point, Cell>
                } 
     with 
         static member Empty = 
            {Cells =  Digits.AllDigits2D |> List.fold (fun acc x -> Map.add x (Cell.CanBe (Set.ofList Digits.AllDigits)) acc) Map.empty}
