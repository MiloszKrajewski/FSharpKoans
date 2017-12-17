module KoansRunner.Test.GetttingTheWholeOutput

open FSharpKoans.Core
open Xunit

let private test<'T> (a: 'T) (b: 'T) = Xunit.Assert.Equal(a, b)
let private fail message = Xunit.Assert.True(false, message)

type ContainerOne() =
    [<Koan>]
    static member One() =
        "FTW!"
        
    [<Koan>]
    static member Two() =
        "FTW!"
        
    [<Koan>]
    static member Three() =
        "FTW!"
        
type ContainerTwo() =
    [<Koan>]
    static member Four() =
        "FTW!"
    
    [<Koan>]
    static member Five() =
        fail "Expected"
        

    [<Koan>]
    static member Six() =
        "FTW!"
        
[<Fact>]
let ``Output contains container name followed by koan results. Stops on failure`` () =
    let runner = KoanRunner([| typeof<ContainerOne>; typeof<ContainerTwo> |])
    let result = runner.ExecuteKoans()
    
    let expected = 
        "

ContainerOne:
    One passed
    Two passed
    Three passed

ContainerTwo:
    Four passed
    Five failed."
    
    
    test expected result.Message