namespace Sudoku

open Digit
open Cell
open Board
open System.IO

module Import=

    [<Literal>] 
    let private separator = ';'

    [<Literal>] 
    let private offset = 1

    let private parseCell readCell  = 
        let parsed = System.Int32.TryParse(readCell)
        match parsed with
        | (true, value) -> Known (Digits.ToDigit (value - offset)) 
        | (false, _) -> AnyOf Digits.AllDigits

    let private parseLine lineNumber (line:string)  =
        let createPos x  = (Digits.ToDigit x, Digits.ToDigit lineNumber)
        Array.take(Digits.NumberOfDigits) (line.Split(separator)) |>
        Seq.mapi (fun i item -> (createPos i), (parseCell item))

    let private filterLines lines = 
        let lines = Seq.filter (fun (line:string) -> line.Contains(string(separator)) ) lines
        lines

    let Import lines =
        let cells =
            lines  |>
            filterLines |>
            Seq.mapi parseLine |>
            Seq.concat |>
            Map.ofSeq 
        {Cells = cells}

    let ImportFile file =
        File.ReadAllLines file |> Import

