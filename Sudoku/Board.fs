namespace Sudoku

open Cell
open Digit

module Board =
    type Board= {
         Cells : Map<Digit * Digit, Cell>
                } 
