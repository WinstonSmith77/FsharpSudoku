namespace Sudoku

open Digit

module Cell=

    type Cell =
        | Known of Digit
        | AnyOf of Digit Set
