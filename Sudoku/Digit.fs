namespace Sudoku

module Digit=
 
    type Digits =
     | One 
     | Two 
     | Three 

     | Four
     | Five
     | Six     

     | Seven
     | Eight
     | Nine  
    with
      static member NumberOfDigits = 
             List.length Digits.AllDigitsAsList
      
      static member private AllDigitsAsList =  [Digits.One; Digits.Two; Digits.Three;
                                 Digits.Four; Digits.Five; Digits.Six;
                                 Digits.Seven; Digits.Eight; Digits.Nine]

      static member AllDigits =  Digits.AllDigitsAsList|> Set.ofList

      member x.ToInt =
        List.findIndex (fun item -> item = x) Digits.AllDigitsAsList 
      
      static member ToDigit x =
         Digits.AllDigitsAsList.[x] 
   
      static member AllDigits2D = 
                                 seq{
                                  for x in Digits.AllDigits do 
                                   for y in Digits.AllDigits do
                                      yield x, y
                                   } |> List.ofSeq
    type Point =  Digits * Digits 
       
           

