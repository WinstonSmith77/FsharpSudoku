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
             List.length Digit.AllDigitsAsList
      
      static member private AllDigitsAsList =  [Digit.One; Digit.Two; Digit.Three;
                                 Digit.Four; Digit.Five; Digit.Six;
                                 Digit.Seven; Digit.Eight; Digit.Nine]

      static member AllDigits =  Digit.AllDigitsAsList|> Set.ofList

      static member private ToInt x =
        List.findIndex (fun item -> item = x) Digit.AllDigitsAsList 
      
      static member ToDigit x =
         Digit.AllDigitsAsList.[x] 

      static member (+) (digit, shift) =
           Digit.ToDigit((Digit.ToInt digit) + shift)
   
      static member AllDigits2D = 
                                 seq{
                                  for x in Digit.AllDigits do 
                                   for y in Digit.AllDigits do
                                      yield x, y
                                   } |> List.ofSeq
  
       
           

