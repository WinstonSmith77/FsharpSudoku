namespace Sudoku

open Digit

module Cell=

    type Cell =
        | Known of Digits
        | UnKnown of Digits Set
