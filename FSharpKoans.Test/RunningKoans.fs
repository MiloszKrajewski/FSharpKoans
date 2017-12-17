module KoansRunner.Test.RunningKoans

open FSharpKoans.Core
open Xunit
open System

let private test<'T> (a: 'T) (b: 'T) = Xunit.Assert.Equal(a, b)
let private fail message = raise (Xunit.Sdk.XunitException(message)) |> ignore

type FailureContainer() =
    [<Koan>]
    static member FailureKoan() =
        fail "expected failure"
        
type SuccessContainer() =
    [<Koan>]
    static member SuccessKoan() =
        "FTW!"

type SomeSuccesses() =
    [<Koan>]
    static member One() =
        "YAY"
    
    [<Koan>]
    static member Two() =
        "WOOT"
        
type MixedBag() =
    [<Koan>]
    static member One() =
        fail "Game over"
    
    [<Koan>]
    static member Two() =
        "OH YEAH!"
        
[<Fact>]
let ``A failing koan returns its exception`` () =
    let result = 
        typeof<FailureContainer>
        |> KoanContainer.runKoans
        |> Seq.head
        
    let ex = 
        match result with
        | Failure (_, ex) -> ex
        | _ -> null
    
    test "expected failure" ex.Message
    
[<Fact>]
let ``A failing koan returns a failure message`` () =
    let result = 
        typeof<FailureContainer>
        |> KoanContainer.runKoans
        |> Seq.head
        
    test "FailureKoan failed." result.Message

[<Fact>]
let ``A successful koans returns a success message`` () =
    let result =
        typeof<SuccessContainer>
        |> KoanContainer.runKoans
        |> Seq.head
        
    test "SuccessKoan passed" result.Message
    
[<Fact>]
let ``The outcome of all successful koans is returned`` () =
    let result =
        typeof<SomeSuccesses>
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
    
    let expected =
        "One passed" + System.Environment.NewLine +
        "Two passed"
        
    test expected result
    
[<Fact>]
//might want to change this behavior
let ``Failed Koans don't stop the enumeration`` () =
    let result =
        typeof<MixedBag>
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
        
    let expected =
        "One failed." + System.Environment.NewLine +
        "Two passed"
        
    test expected result
