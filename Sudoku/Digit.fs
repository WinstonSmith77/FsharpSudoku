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
             List.length Digits.AllDigits
      
      static member AllDigits =  [Digits.One; Digits.Two; Digits.Three;
                                 Digits.Four; Digits.Five; Digits.Six;
                                 Digits.Seven; Digits.Eight; Digits.Nine]
      member x.ToInt =
        List.findIndex (fun item -> item = x) Digits.AllDigits 
      
      static member ToDigit x =
         Digits.AllDigits.[x] 
   
      static member AllDigits2D = 
                                 seq{
                                  for x in Digits.AllDigits do 
                                   for y in Digits.AllDigits do
                                      yield x, y
                                   } |> List.ofSeq
    type Point =  Digits * Digits 
       
           

