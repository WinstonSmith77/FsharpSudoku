namespace Sudoku

module Solver=
    open Digit

    let splitLine (line:string) =
        line.Split(';') |> Seq.mapi (fun i item -> Digits.ToDigit (i + 1), Digits.ToDigit (System.Int32.Parse(item)))

    let Import lines =
        let lines = Seq.filter (fun (line:string) -> line.Contains(";") ) lines
        Seq.head lines |> splitLine

