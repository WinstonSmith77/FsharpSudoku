namespace Tests

open NUnit.Framework
open System.IO
open System.Reflection
open Sudoku.Import

module SolverTest=
  

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.ImportTest()  =
            let dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            let file = Path.Combine(dir, "data.txt")

            let board =  File.ReadAllLines file |> Import
            ()
           
          
            

      

      