namespace Sudoku

open Digit
open Cell
open Board
open Range

module Verifer=
    open System.Diagnostics

    let private areAllDigitsInRange cellvalues  =
         let cellvaluesAsList = List.ofSeq cellvalues 
         let allDigitsInSet digits = (digits=Digits.AllDigits) 
         let rec areAllDigitsInRangeInner cellvaluesAsList digits  =
            match  List.head cellvaluesAsList with
            | Known digit -> 
                    let digits = Set.add digit digits
                    match List.tail cellvaluesAsList with   
                         | [] -> allDigitsInSet digits 
                         | tail -> areAllDigitsInRangeInner tail digits
            | AnyOf _ -> false
         areAllDigitsInRangeInner cellvaluesAsList  Set.empty    
        

    let private trueForAnyRange range cells =
        let rangeCellValues = Set.fold (fun set pos -> Set.add (Map.find pos cells) set) Set.empty range
        areAllDigitsInRange rangeCellValues
       

    let private verifyCells cells =
        Set.forall (fun range -> trueForAnyRange range cells) AllRanges 

    let Verify board =
        verifyCells board.Cells
