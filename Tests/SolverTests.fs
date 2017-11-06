namespace Tests

open NUnit.Framework
open System.IO
open System.Reflection
open Sudoku.Import
open Sudoku.Solver
open Sudoku.Verifer

module SolverTest=
   

    [<TestFixture>]
    type MethodTests() =

        member x.TestFilePath=
             let dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             Path.Combine(dir, "data.txt")

        [<Test>]
        member x.ImportTest()  =
            let result = ImportFile x.TestFilePath
            ()

        [<Test>]
        member x.SolverTest()  =
            let task = ImportFile x.TestFilePath
            let result = Solver task
            
            match result with
            | None -> Assert.Fail("No Solution")
            | Some _ -> ()
          

            ()
           
          
            

      

      