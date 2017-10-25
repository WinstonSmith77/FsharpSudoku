namespace Tests

open NUnit.Framework
open System.IO
open System.Reflection
open Sudoku.Import
open Sudoku.Solver

module SolverTest=
    
  

    [<TestFixture>]
    type MethodTests() =
        [<Test>]
        member x.ImportTest()  =
            let dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            let file = Path.Combine(dir, "data.txt")
            
            let result = ImportFile file
            ()
        
        [<Test>]
        member x.SolverTest()  =
            let dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            let file = Path.Combine(dir, "data.txt")
            
            let task = ImportFile file
            let result = Solver task
            ()
           
          
            

      

      