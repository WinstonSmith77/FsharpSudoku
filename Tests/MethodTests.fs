namespace Tests

open NUnit.Framework
open Sudoku.Range

module MethodTests=

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.Range()  =
            let allRanges = AllRanges
            let tester key value =
                    let shouldBeTrue = Set.count value = 20
                    match shouldBeTrue with
                        |false -> Assert.Fail(key.ToString())
                        |true -> ()
                    ()
            Map.iter tester allRanges
          
            

      

      