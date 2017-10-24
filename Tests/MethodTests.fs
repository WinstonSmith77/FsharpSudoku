namespace Tests

open NUnit.Framework
open Sudoku.Range

module MethodTests=

    let areaOfTestCircle = System.Math.PI * 2.0 * 2.0 * 2.0
    let circumferenceOfTestCircle = System.Math.PI * 2.0 

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.Range()  =
            let allRanges = AllRanges
            Map.iter (fun key value -> Assert.AreEqual((Set.count value), 20)) allRanges
          
            

      

      