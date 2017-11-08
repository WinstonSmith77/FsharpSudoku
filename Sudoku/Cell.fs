﻿namespace Sudoku

open Digit

module Cell=
    open System.ComponentModel

    type Cell =
        | Known of Digit
        | AnyOf of Digit Set
