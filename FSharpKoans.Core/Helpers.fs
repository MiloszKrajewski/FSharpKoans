[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers

open System
open Xunit

let inline __<'T> : 'T = failwith "Seek wisdom by filling in the __"

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let AssertWithMessage (x: bool) message = Assert.True(x, message)

let AssertEquality (x:'T) (y:'T) = Assert.Equal<'T>(x, y)   

let AssertInequality (x:'T) (y:'T) = Assert.NotEqual<'T>(x, y)

let AssertThrows<'E when 'E :> exn> action = Assert.Throws<'E>(Action(action))

let Assert (x: bool) = Assert.True(x)
