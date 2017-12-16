open System
open FSharpKoans.Core

let line60 = new string('-', 60)

printf "\n\n\n%s\n\n\n" line60

let runner = KoanRunner()
let result = runner.ExecuteKoans()

match result with
| Success message -> printf "%s" message
| Failure (message, ex) -> 
    printf "%s" message
    printfn ""
    printfn ""
    printfn ""
    printfn ""
    printfn "You have not yet reached enlightenment ..."
    printfn "%s" ex.Message
    printfn ""
    printfn "Please meditate on the following code:"
    printfn "%s" ex.StackTrace

printf "\n\n\n%s\n%s\n\n\n" (DateTime.Now.ToString ()) line60
