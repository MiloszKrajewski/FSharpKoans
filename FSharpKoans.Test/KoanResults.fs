module KoansRunner.Test.KoanResults

open FSharpKoans.Core
open Xunit

let private test<'T> (a: 'T) (b: 'T) = Xunit.Assert.Equal(a, b)
let private fail message = Xunit.Assert.True(false, message)

[<Fact>]
let ``map lets you project a message when success``() =
    let result = Success "sample message"

    let mappedResult = 
        result
        |> KoanResult.map (fun x -> x + " expanded")

    test (Success "sample message expanded") mappedResult

[<Fact>]
let ``map lets you project a message when failure``() =
    let ex = System.Exception("abcd")
    let result = Failure ("sample message", ex)

    let mappedResult = 
        result
        |> KoanResult.map (fun x -> x + " expanded")

    test (Failure ("sample message expanded", ex)) mappedResult