namespace Sudoku

module Digit=
 
    type Digit =
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
             List.length Digit.allDigitsAsList
      
      static member private allDigitsAsList =  [Digit.One; Digit.Two; Digit.Three;
                                 Digit.Four; Digit.Five; Digit.Six;
                                 Digit.Seven; Digit.Eight; Digit.Nine]

      static member AllDigits =  Digit.allDigitsAsList|> Set.ofList

      static member private ToInt x =
        List.findIndex (fun item -> item = x) Digit.allDigitsAsList 
      
      static member IntToDigit x =
         Digit.allDigitsAsList.[x] 

      static member (+) (digit, shift) =
           Digit.IntToDigit((Digit.ToInt digit) + shift)
   
      static member AllDigits2D = 
                                 seq{
                                  for x in Digit.AllDigits do 
                                   for y in Digit.AllDigits do
                                      yield x, y
                                   } |> List.ofSeq
  
       
           

