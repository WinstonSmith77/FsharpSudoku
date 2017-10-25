namespace Sudoku

open Digit

module Cell=
    open System.ComponentModel

    type Cell =
        | Known of Digits
        | AnyOf of Digits Set
