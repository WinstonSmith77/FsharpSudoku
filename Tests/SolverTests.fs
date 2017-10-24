namespace Tests

open NUnit.Framework
open System.IO
open System.Reflection
open Sudoku.Solver

module SolverTest=
  

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.SolverTest()  =
            let dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            let file = Path.Combine(dir, "data.txt")

            let allLines =  File.ReadAllLines file |> Import
            ()
           
          
            

      

      