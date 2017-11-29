namespace Tests

open NUnit.Framework
open Sudoku.Range

module RangesTests=
    open Sudoku.Digit

    [<TestFixture>]
    type MethodTests() =
       
       [<Test>]
        member x.CellsInCombinedRanges()  =
            let shouldBeTrue _ range = Set.count range = 20
            let trueForAll = Map.forall shouldBeTrue AllCombinedNeighborRangesForCell

            Assert.That(trueForAll)

        [<Test>]
        member x.NumberOfCombinedRanges()  =
            Assert.AreEqual(Map.count AllCombinedNeighborRangesForCell,List.length Digit.AllDigits2D)

        [<Test>]
        member x.AllCellThreeTimesInRange()  =
            let allPositionsAppearThreeTimes
                    = Set.toList AllRanges
                        |> List.collect (fun set -> Set.toList set)
                        |> List.groupBy (fun item -> item)
                        |> List.map (fun (_, list) -> List.length list)
                        |> List.forall (fun count -> count = 3)
            Assert.That(allPositionsAppearThreeTimes)


        