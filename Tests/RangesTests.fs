namespace Tests

open NUnit.Framework
open Sudoku.Range

module RangesTests=
    open Sudoku.Digit

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.RangeCount()  =
            let allRanges = AllRanges
            let tester key value =
                    let shouldBeTrue = Set.count value = 20
                    match shouldBeTrue with
                        |false -> Assert.Fail(key.ToString())
                        |true -> ()
                    ()
            Map.iter tester allRanges

        [<Test>]
        member x.NumberOfRanges()  =
            let allRanges = AllRanges
            Assert.AreEqual(Map.count allRanges,List.length Digits.AllDigits2D)
           
           
          
            

      

      